namespace GameScriptManager
{
    public class Node
    {
        public int StoryNumber;
        public string StoryText;
        public Node Next;

        public Node(int storyNumber, string storyText)
        {
            StoryNumber = storyNumber;
            StoryText = storyText;
            Next = null;
        }
    }
}