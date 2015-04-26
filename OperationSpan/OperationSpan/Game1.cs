#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Diagnostics;
#endregion

namespace OperationSpan
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        int trialSize = 4; // current number of letters to remember;

        // valid consonants for recall selection, per the WMC Battery study
        string[] letterArray = new string[] { "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "R", "S", "T", "V", "W", "X", "Z" };

        #region Game State Variables
        bool addingToList = false;
        bool isEquation = false;
        bool isLetter = false;
        bool isRecall = false;
        #endregion

        #region Equation Cycle Variables
        int value1;
        int value2;
        int value3;
        Stopwatch equationDelay;
        bool equationAnswered = false;
        #endregion

        #region Letter Cycle Variables
        string equationAnswers; // system's answers on whether equations were correct or not
        string equationSelections; // user's answers on whether equations were correct or not
        string letter;
        string letterAnswers; // system's storage of the letters to remember
        string letterSelections; // user's answers on the letters to remember
        #endregion

        #region Recall Cycle Variables
        string recallSelection = "";
        bool waitingOnSelection = true;
        #endregion

        #region Scoring Variables
        int rightEquations = 0;
        float equationPercentage = 0;
        int rightLetters = 0;
        float letterPercentage = 0;
        #endregion

        Random random;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            random = new Random();
            equationDelay = new Stopwatch();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
        }

        /// <summary>
        /// Thread for running equation/letter display cycle
        /// </summary>
        /// <param name="obj"></param>
        public void EquationLetterCycle(Object obj)
        {
            while (addingToList)
            {
                // create an equation where lhs = rhs 50% of the time
                value1 = random.Next(10) + 1;
                value2 = random.Next(10) + 1;
                if(random.Next(2) == 0)
                {
                    value3 = value1 + value2; // lhs = rhs (correct equation)
                    equationAnswers += "y";
                }
                else
                {
                    value3 = random.Next(19) + 2; // lhs =/= rhs (incorrect equation)
                    while (value3 == value1 + value2)
                    {
                        value3 = random.Next(19) + 2; // failsafe to prevent lhs = rhs by random value
                    }
                    equationAnswers += "n";
                }

                // wait for the user to answer or timeout after 3 seconds
                equationDelay.Restart();
                while(equationDelay.ElapsedMilliseconds < 3000)
                {
                    if(equationAnswered)
                    {
                        break; // user selected an answer before the time limit
                    }
                }
                if(!equationAnswered)
                {
                    equationSelections += "x"; // user failed to select an answer before the time limit
                }
                equationAnswered = false;
                equationDelay.Stop();
                isEquation = false;

                isLetter = true;
                letter = letterArray[random.Next(19)];
                letterAnswers += letter;
                System.Threading.Thread.Sleep(1000);
                isLetter = false;

                System.Threading.Thread.Sleep(100);
                if (letterAnswers.Length >= trialSize)
                {
                    addingToList = false;
                    isRecall = true; // conclude equation/letter cycles
                }
                else
                {
                    isEquation = true; // continue equation/letter cycles
                }
            }
        }

        /// <summary>
        /// Thread for running recall cycle
        /// </summary>
        /// <param name="obj"></param>
        public void RecallCycle(object obj)
        {
            while(!waitingOnSelection)
            {
                System.Threading.Thread.Sleep(500);

                if(letterSelections.Length >= letterAnswers.Length)
                {
                    isRecall = false; // conclude recall cycle

                    #region Scoring
                    rightEquations = 0;
                    equationPercentage = 0;
                    rightLetters = 0;
                    letterPercentage = 0;
                    for (int i = 0; i < equationSelections.Length; i++ )
                    {
                        if (equationSelections[i] == equationAnswers[i])
                        {
                            rightEquations++;
                        }
                    }
                    equationPercentage = (float)rightEquations / trialSize;

                    for (int i = 0; i < letterSelections.Length; i++)
                    {
                        if (letterSelections[i] == letterAnswers[i])
                        {
                            rightLetters++;
                        }
                    }
                    letterPercentage = (float)rightLetters / trialSize;
                    #endregion
                }

                waitingOnSelection = true;
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            #region Equation/Letter Cycle
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !addingToList)
            {
                // reset values
                addingToList = true;
                isEquation = true;
                equationAnswers = "";
                equationSelections = "";
                letter = "";
                letterAnswers = "";
                letterSelections = "";
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(EquationLetterCycle));
            }

            // user has answered whether the equation is correct or not
            if (Keyboard.GetState().IsKeyDown(Keys.OemQuestion) && isEquation)
            {
                equationAnswered = true;
                equationSelections += "y";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Z) && isEquation)
            {
                equationAnswered = true;
                equationSelections += "n";
            }
            #endregion

            #region Recall Cycle
            if (Keyboard.GetState().GetPressedKeys().Length > 0 && isRecall && waitingOnSelection)
            {
                recallSelection = Keyboard.GetState().GetPressedKeys()[0].ToString();
                for(int i = 0; i < letterArray.Length; i++)
                {
                    if (recallSelection == letterArray[i])
                    {
                        waitingOnSelection = false; // user pressed a valid key
                    }
                }

                if(!waitingOnSelection)
                {
                    letterSelections += recallSelection;
                    System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(RecallCycle));
                }
            }
            #endregion

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            #region Equation Cycle
            if (isEquation)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, value1 + " + " + value2 + " = " + value3, new Vector2(200, 200), Color.Black);
                //spriteBatch.DrawString(font, "" + equationDelay.ElapsedMilliseconds, new Vector2(200, 220), Color.Black);
                //spriteBatch.DrawString(font, equationAnswers, new Vector2(200, 240), Color.Black);
                //spriteBatch.DrawString(font, equationSelections, new Vector2(200, 260), Color.Black);
                spriteBatch.End();
            }
            #endregion

            #region Letter Cycle
            if (isLetter)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, letter, new Vector2(200, 200), Color.Black);
                //spriteBatch.DrawString(font, letterAnswers, new Vector2(200, 220), Color.Black);
                spriteBatch.End();
            }
            #endregion

            #region Recall Cycle
            if (isRecall)
            {
                if (waitingOnSelection)
                {
                    spriteBatch.Begin();
                    spriteBatch.DrawString(font, "_", new Vector2(200, 200), Color.Black);
                    spriteBatch.End();
                }
                else
                {
                    spriteBatch.Begin();
                    spriteBatch.DrawString(font, recallSelection, new Vector2(200, 200), Color.Black);
                    //spriteBatch.DrawString(font, letterSelections, new Vector2(200, 220), Color.Black);
                    spriteBatch.End();
                }
            }
            #endregion

            #region Score Debugging
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "" + equationPercentage + "    " + letterPercentage, new Vector2(200, 300), Color.Black);
            spriteBatch.End();
            #endregion

            base.Draw(gameTime);
        }
    }
}
