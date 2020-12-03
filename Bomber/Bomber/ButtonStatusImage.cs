using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Bomber
{
    static class ButtonStatusImage
    {
        public static Image Empty {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell0.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell0.png");
                }
                else
                {
                    return null;
                }
            } 
        }
        public static Image One { get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell1.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell1.png");
                }
                else
                {
                    return null;
                }
            }
        }
        public static Image Two { get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell2.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell2.png");
                }
                else
                {
                    return null;
                }

            }
        }
        public static Image Three
        {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell3.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell3.png");
                }
                else
                {
                    return null;
                }

            }
        }
        public static Image Four
        {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell4.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell4.png");
                }
                else
                {
                    return null;
                }

            }
        }
        public static Image Five
        {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell5.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell5.png");
                }
                else
                {
                    return null;
                }

            }
        }
        public static Image Six
        {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell6.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell6.png");
                }
                else
                {
                    return null;
                }

            }
        }
        public static Image Seven
        {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell7.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell7.png");
                }
                else
                {
                    return null;
                }

            }
        }
        public static Image Eight
        {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell8.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cell8.png");
                }
                else
                {
                    return null;
                }

            }
        }
        public static Image Flag
        {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cellflag.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cellflag.png");
                }
                else
                {
                    return null;
                }

            }
        }
        public static Image Bomb
        {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cellbomb.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cellbomb.png");
                }
                else
                {
                    return null;
                }

            }
        }
        public static Image FakeBomb
        {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cellfakebomb.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cellfakebomb.png");
                }
                else
                {
                    return null;
                }

            }
        }
        public static Image QuestionMark
        {
            get
            {
                if (File.Exists(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cellquestionmark.png"))
                {
                    return Image.FromFile(@"C:\Users\lemur\Desktop\LearningAndStudying\Bomber\Bomber\Sprites\cellquestionmark.png");
                }
                else
                {
                    return null;
                }

            }
        }




    }
}
