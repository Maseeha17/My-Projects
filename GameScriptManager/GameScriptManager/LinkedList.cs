using System.Text;

namespace GameScriptManager
{
    public class LinkedList
    {
        public Node Head;

        public void Add(int number, string text)
        {
            Node newNode = new Node(number, text);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node current = Head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }


        public void BubbleSort()
        {
            if (Head == null)
                return;

            bool swapped;

            do
            {
                swapped = false;

                Node current = Head;

                while (current.Next != null)
                {
                    if (current.StoryNumber > current.Next.StoryNumber)
                    {
                        int tempNumber = current.StoryNumber;
                        string tempText = current.StoryText;

                        current.StoryNumber = current.Next.StoryNumber;
                        current.StoryText = current.Next.StoryText;

                        current.Next.StoryNumber = tempNumber;
                        current.Next.StoryText = tempText;

                        swapped = true;
                    }

                    current = current.Next;
                }

            } while (swapped);
        }


        public string GetFullStory()
        {
            StringBuilder story = new StringBuilder();

            Node current = Head;

            while (current != null)
            {
                story.AppendLine($"Story {current.StoryNumber}");
                story.AppendLine(current.StoryText);
                story.AppendLine();

                current = current.Next;
            }

            return story.ToString();
        }
    }
}