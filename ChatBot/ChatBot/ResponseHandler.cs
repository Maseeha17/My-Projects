using Chatbot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;

namespace ChatBot
{
    public static class ResponseHandler
    {
        private static string lastTopic = "";
        private static string userName = "";
        private static string userInterest = "";

        private static bool waitingForTipConfirmation = false;

        private static Random random = new Random();

        private static Dictionary<string, List<int>> usedResponses = new Dictionary<string, List<int>>();

        private static Dictionary<string, List<string>> keywordAnswers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            //
            //National Cyber Security Centre (NCSC). (2023) *Password guidance*. [Online] 
            // Available at: https://www.ncsc.gov.uk/guidance/password-guidance-simplifying-your-approach 
            //(Accessed: 26 May 2025).
            //
            { "password", new List<string> {
                "Use strong, unique passwords with a mix of letters, numbers, and symbols.",
                "Avoid using the same password across different sites.",
                "Consider using a password manager to keep your credentials safe.",
                "Change your passwords regularly, especially for sensitive accounts.",
                "Enable Two-Factor Authentication (2FA) for an extra layer of security."
            }},
            { "phishing", new List<string> {
                "Watch for urgent messages and threats demanding immediate action.",
                "Check the sender’s email address — it may look fake or suspicious.",
                "Hover over links before clicking to see if the URL looks legitimate.",
                "Look for bad grammar or generic greetings in suspicious emails.",
                "Banks and services rarely ask for personal info over email — when in doubt, contact them directly."
            }},
            //
            // Norton. (2023) *What is malware?*. [Online] 
            //Available at: https://us.norton.com/blog/malware/what-is-malware 
            //(Accessed: 26 May 2025).
            //
            { "malware", new List<string> {
                "Malware is software designed to damage your device or steal data.",
                "Avoid downloading attachments from unknown sources.",
                "Install antivirus software and keep it updated.",
                "Be cautious of free software downloads — they may contain hidden malware.",
                "Regularly scan your device for malware and remove any threats."
            }},
            { "public wifi", new List<string> {
                "Avoid logging into banking or sensitive accounts on public Wi-Fi.",
                "Use a VPN when accessing the internet through public networks.",
                "Disable automatic connection to open Wi-Fi networks."
            }},
            //
            //OpenAI (2024) *ChatGPT* [Computer program]. Available at: https://chat.openai.com (Accessed: 26 May 2025).
            //
            { "vpn", new List<string> {
                "A VPN encrypts your traffic and hides your IP address.",
                "VPNs help protect your identity on public networks.",
                "Choose a reputable VPN provider for better security."

            }},
            { "firewall", new List<string> {
                "A firewall helps block unauthorized access to your device.",
                "Keep your firewall enabled to help stop threats before they reach you."
            }},
            { "2fa", new List<string> {
                "Two-Factor Authentication adds an extra layer of security.",
                "Use 2FA wherever possible to protect your accounts."
            }},
            { "update software", new List<string> {
                "Software updates often include security patches — don’t ignore them!",
                "Enable auto-updates to stay protected from the latest threats."
            }},
            { "identity theft", new List<string> {
                "Monitor your financial accounts for strange activity.",
                "Avoid oversharing personal details on social media."
            }},
            { "cyberbullying", new List<string> {
                "Block and report abusive users online.",
                "Talk to someone you trust if you're being bullied digitally."
            }}
        };
        //
        //OpenAI (2024) *ChatGPT* [Computer program]. Available at: https://chat.openai.com (Accessed: 26 May 2025).
        //
        private static Dictionary<string, string> interestRecommendations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "phishing", "Enable spam filters and never click suspicious links in emails." },
            { "password", "Use a password manager to store and generate secure passwords." },
            { "vpn", "Consider using a VPN, especially when using public Wi-Fi." },
            { "identity theft", "Regularly check your bank statements and credit report." },
            { "malware", "Keep your antivirus software updated to detect threats." },
            { "social media", "Limit what personal info you share on your profiles." },
            { "public wifi", "Avoid doing online banking on public networks — use mobile data if possible." }
        };

        private static string[] generalTips = {
            "Remember to log out of accounts after using public computers.",
            "Think before you click — especially on suspicious links.",
            "Always use secure connections (look for HTTPS).",
            "Be cautious of attachments or downloads from unknown sources."
        };

        public static void RespondToUser(string input)
        {
            string lowerInput = input.ToLower();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nCYBOT: ");
            Console.ResetColor();

            // Check if waiting for a tip confirmation
            if (lowerInput == "yes" && waitingForTipConfirmation && !string.IsNullOrEmpty(userInterest))
            {
                waitingForTipConfirmation = false;

                if (interestRecommendations.TryGetValue(userInterest, out var tip))
                {
                    Console.WriteLine($"Here's a tip based on your interest in {userInterest}: {tip}");
                }
                else
                {
                    Console.WriteLine($"I don’t have a specific tip for {userInterest}, but always stay alert and practice good cybersecurity habits!");
                }
                return;
            }

            // Detect and store user's name
            if (Regex.IsMatch(lowerInput, @"my name is (\w+)", RegexOptions.IgnoreCase))
            {
                userName = Regex.Match(lowerInput, @"my name is (\w+)", RegexOptions.IgnoreCase).Groups[1].Value;
                Console.WriteLine($"Nice to meet you, {userName}!");
                return;
            }

            if (lowerInput.Contains("interested in"))
            {
                var match = Regex.Match(lowerInput, @"interested in (.+)", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    string newInterest = match.Groups[1].Value.Trim().TrimEnd('.');

                    if (!string.IsNullOrEmpty(userInterest) &&
                        userInterest.Equals(newInterest, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"You've already told me you're interested in {userInterest}. Let's build on that — review your privacy settings and app permissions regularly.");
                    }
                    else
                    {
                        userInterest = newInterest;
                        Console.WriteLine($"Great! I'll remember that you're interested in {userInterest}. It's a crucial part of staying safe online.");
                        Console.WriteLine($"Based on your interest in {userInterest}, I recommend learning more about how to protect yourself. Want to hear a tip?");
                        waitingForTipConfirmation = true;
                    }
                    return;
                }
            }

            // Reference interest
            if (lowerInput.Contains("remind me") && !string.IsNullOrEmpty(userInterest))
            {
                Console.WriteLine($"Earlier you mentioned you're interested in {userInterest}. Here's something helpful: Always check your privacy settings on your accounts.");
                return;
            }

            // Sentiment detection
            if (lowerInput.Contains("worried"))
            {
                Console.WriteLine("It's okay to feel worried. I'm here to help you navigate safely online.");
                return;
            }
            if (lowerInput.Contains("frustrated"))
            {
                Console.WriteLine("I understand your frustration. Let’s take it one step at a time.");
                return;
            }
            if (lowerInput.Contains("curious"))
            {
                Console.WriteLine("Curiosity is great! Let's explore some cybersecurity tips.");
                return;
            }

            // Confusion
            if (lowerInput.Contains("don't understand") || lowerInput.Contains("confused"))
            {
                if (!string.IsNullOrEmpty(lastTopic) && keywordAnswers.TryGetValue(lastTopic, out var helpResponses))
                {
                    Console.WriteLine("Let me explain again: " + GetUniqueResponse(lastTopic, helpResponses));
                }
                else
                {
                    Console.WriteLine("No worries — feel free to ask another question.");
                }
                return;
            }

            // Keyword match
            foreach (var pair in keywordAnswers)
            {
                if (lowerInput.Contains(pair.Key))
                {
                    lastTopic = pair.Key;
                    string response = GetUniqueResponse(pair.Key, pair.Value);
                    if (!string.IsNullOrEmpty(userName))
                        Console.WriteLine($"{userName}, here's a tip: {response}");
                    else
                        Console.WriteLine(response);
                    return;
                }
            }

            // More info
            if (lowerInput.Contains("more") && !string.IsNullOrEmpty(lastTopic))
            {
                if (keywordAnswers.TryGetValue(lastTopic, out var moreResponses))
                {
                    Console.WriteLine("Here's more: " + GetUniqueResponse(lastTopic, moreResponses));
                }
                else
                {
                    Console.WriteLine("I don’t have more info on that topic right now.");
                }
                return;
            }

            // Exit
            if (lowerInput.Contains("exit") || lowerInput.Contains("bye"))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Goodbye{(string.IsNullOrEmpty(userName) ? "" : ", " + userName)}! Stay safe out there{(string.IsNullOrEmpty(userInterest) ? "." : $" — especially around {userInterest}.")}");
                Console.ResetColor();
                Environment.Exit(0);
            }

            // Fallback with interest-based tip
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            if (!string.IsNullOrEmpty(userInterest))
            {
                Console.WriteLine($"Hmm... I didn't quite get that. Since you're interested in {userInterest}, here's a helpful tip: Review your privacy settings and limit app permissions.");
            }
            else
            {
                string tip = generalTips[random.Next(generalTips.Length)];
                Console.WriteLine($"Hmm... I didn't quite get that. Here's a general tip: {tip}");
            }

            Console.ResetColor();
        }
        //random response variation
        private static string GetUniqueResponse(string topic, List<string> responses)
        {
            if (!usedResponses.ContainsKey(topic))
                usedResponses[topic] = new List<int>();

            var usedIndexes = usedResponses[topic];
            if (usedIndexes.Count >= responses.Count)
                usedIndexes.Clear();

            List<int> availableIndexes = new List<int>();
            for (int i = 0; i < responses.Count; i++)
            {
                if (!usedIndexes.Contains(i))
                    availableIndexes.Add(i);
            }

            int chosenIndex = availableIndexes[random.Next(availableIndexes.Count)];
            usedIndexes.Add(chosenIndex);

            return responses[chosenIndex];
        }
    }
}


