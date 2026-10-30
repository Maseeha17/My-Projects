using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameScriptManager
{
    public partial class MainForm : Form
    {
        private LinkedList storyList = new LinkedList();
        private List<Node> storyNodes = new List<Node>();
        private int currentIndex = 0;

        public MainForm()
        {
            InitializeComponent();

            rbFull.Checked = true;

            txtCurrentLine.Visible = false;
            lblCurrent.Visible = false;

            // Styling
            this.BackColor = Color.AliceBlue;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            lblTitle.ForeColor = Color.DarkBlue;

            btnLoad.BackColor = Color.RoyalBlue;
            btnLoad.ForeColor = Color.White;

            btnPrevious.BackColor = Color.IndianRed;
            btnPrevious.ForeColor = Color.White;

            btnNext.BackColor = Color.SeaGreen;
            btnNext.ForeColor = Color.White;
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            storyList = new LinkedList();

            storyList.Add(3, "With every line of code mastered, Alex gains experience points, leveling up and unlocking new abilities like Debugging Dash and Algorithmic Aura.");

            storyList.Add(12, "The tale of Alex, the IT student-turned-digital-legend, is forever etched in the annals of Cybersphere, inspiring aspiring programmers to pursue their dreams.");

            storyList.Add(4, "The Firewall Fortress looms ahead, its defenses formidable, but Alex's mastery of cybersecurity allows them to breach the walls with a series of perfectly timed hacks.");

            storyList.Add(2, "Armed with a trusty keyboard and a digital sword, Alex enters the Coding Caverns, where bugs and glitches guard the treasures of programming wisdom.");

            storyList.Add(1, "In the virtual realm of Cybersphere, our hero, Alex, a determined IT student, embarks on an epic quest for knowledge.");

            storyList.Add(7, "Along the journey, Alex forges alliances with NPC coders, forming a guild known as Syntax Sentinels, united by their dedication to digital mastery.");

            storyList.Add(10, "Victory is hard-won, but Alex's leadership and IT prowess lead to the defeat of the Malware Marauders, restoring peace to Cybersphere.");

            storyList.Add(11, "Celebrated as a digital hero, Alex stands at the forefront of innovation, using the knowledge gained to create groundbreaking applications that shape the future of technology.");

            storyList.Add(9, "In a climactic battle, Alex and the Syntax Sentinels engage in a virtual war, using complex algorithms and strategic thinking to outwit the Malware Marauders' schemes.");

            storyList.Add(5, "Inside the fortress, a virtual reality riddle awaits – a puzzle that can only be solved by applying principles of encryption and decryption learned during countless late-night study sessions.");

            storyList.Add(6, "Emerging victorious, Alex discovers the hidden Repository of the Ancients, a collection of long-lost IT texts rumored to contain the ultimate programming language.");

            storyList.Add(8, "The guild faces its nemesis in the form of the Malware Marauders, a rival group aiming to spread chaos and disrupt the digital realm.");


            storyList.BubbleSort();

            rtbFullScript.Text = storyList.GetFullStory();


            storyNodes.Clear();

            Node current = storyList.Head;

            while (current != null)
            {
                storyNodes.Add(current);
                current = current.Next;
            }

            currentIndex = 0;

            DisplayCurrentStory();
        }


        private void DisplayCurrentStory()
        {
            if (storyNodes.Count == 0)
                return;

            txtCurrentLine.Text =
                $"Story {storyNodes[currentIndex].StoryNumber} of {storyNodes.Count}\r\n\r\n" +
                storyNodes[currentIndex].StoryText;
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < storyNodes.Count - 1)
            {
                currentIndex++;
                DisplayCurrentStory();
            }
        }


        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentStory();
            }
        }


        private void rbFull_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFull.Checked)
            {
                rtbFullScript.Visible = true;
                txtCurrentLine.Visible = false;
                lblCurrent.Visible = false;

                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
            }
        }


        private void rbSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSingle.Checked)
            {
                rtbFullScript.Visible = false;
                txtCurrentLine.Visible = true;
                lblCurrent.Visible = true;

                btnNext.Enabled = true;
                btnPrevious.Enabled = true;
            }
        }
    }
}