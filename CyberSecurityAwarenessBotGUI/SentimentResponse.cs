using System;

namespace CyberSecurityAwarenessBotGUI
{
    // =====================================================
    // SENTIMENTRESPONSE.CS — Emotional Intelligence Layer
    // Detects tone/emotion in user input and responds with
    // empathy before the main cybersecurity answer runs.
    // =====================================================

    class SentimentResponse
    {
        private static readonly Random _rand = new Random();

        public static string GetSentiment(string input)
        {
            string lower = input.ToLower();
            string name = MemoryManager.GetNamePrefix();  // e.g. "Alex, " or ""

            // --------------------------------------------------
            // HAPPY / POSITIVE
            // --------------------------------------------------
            if (lower.Contains("happy") ||
                lower.Contains("great") ||
                lower.Contains("awesome") ||
                lower.Contains("excellent") ||
                lower.Contains("love it") ||
                lower.Contains("thanks") ||
                lower.Contains("thank you") ||
                lower.Contains("good job") ||
                lower.Contains("well done"))
            {
                string[] replies = {
                    name + "That's great to hear! 😊 Staying positive while building cybersecurity awareness is the right mindset. "
                        + "Every question you ask makes you harder to attack.",

                    name + "Glad you're feeling good about this! 😊 Cybersecurity doesn't have to be scary — "
                        + "knowledge really is your strongest defence against online threats.",

                    name + "Love the energy! 😊 You're doing exactly what safe users do — asking questions and staying informed. "
                        + "That puts you ahead of most people online."
                };
                return replies[_rand.Next(replies.Length)];
            }

            // --------------------------------------------------
            // SAD / WORRIED / ANXIOUS
            // --------------------------------------------------
            if (lower.Contains("sad") ||
                lower.Contains("worried") ||
                lower.Contains("anxious") ||
                lower.Contains("scared") ||
                lower.Contains("afraid") ||
                lower.Contains("nervous") ||
                lower.Contains("stressed") ||
                lower.Contains("panic") ||
                lower.Contains("hacked") ||
                lower.Contains("breached") ||
                lower.Contains("leaked"))
            {
                string[] replies = {
                    name + "I understand — discovering a security issue is genuinely stressful. 😟 "
                        + "Take a breath. The most important thing right now is to act calmly and methodically. "
                        + "Tell me what happened and I'll walk you through the right steps.",

                    name + "It's completely normal to feel worried about cybersecurity threats — they are real. 😟 "
                        + "But remember: panic leads to mistakes. Let's work through this together, one step at a time. "
                        + "What specifically is concerning you?",

                    name + "You're not alone in feeling this way. 😟 Many people feel overwhelmed by cyber threats. "
                        + "The good news is that most situations are recoverable if you act quickly and correctly. "
                        + "I'm here to guide you — what do you need help with?"
                };
                return replies[_rand.Next(replies.Length)];
            }

            // --------------------------------------------------
            // ANGRY / FRUSTRATED
            // --------------------------------------------------
            if (lower.Contains("angry") ||
                lower.Contains("frustrated") ||
                lower.Contains("annoyed") ||
                lower.Contains("furious") ||
                lower.Contains("hate this") ||
                lower.Contains("this is stupid") ||
                lower.Contains("terrible") ||
                lower.Contains("useless"))
            {
                string[] replies = {
                    name + "I hear you — being targeted by cybercriminals or scams is infuriating. 😤 "
                        + "That anger is completely justified. Let's channel it into action: the best revenge is "
                        + "making yourself impossible to attack. What happened?",

                    name + "Frustration with cyber threats is valid — they're designed to exploit trust. 😤 "
                        + "I'll help you understand exactly what happened and how to prevent it in future. "
                        + "What are you dealing with?",

                    name + "Totally understandable reaction. 😤 Scams and attacks are deliberately manipulative "
                        + "and no one should have to deal with them. Let me give you clear, direct information "
                        + "to help you take back control."
                };
                return replies[_rand.Next(replies.Length)];
            }

            // --------------------------------------------------
            // CONFUSED / LOST
            // --------------------------------------------------
            if (lower.Contains("confused") ||
                lower.Contains("don't understand") ||
                lower.Contains("dont understand") ||
                lower.Contains("not sure") ||
                lower.Contains("lost") ||
                lower.Contains("unclear") ||
                lower.Contains("complicated") ||
                lower.Contains("too technical"))
            {
                string[] replies = {
                    name + "No worries at all — cybersecurity is full of technical terms that aren't always well explained. 🤔 "
                        + "I'll break everything down into plain language. "
                        + "Tell me exactly what's confusing you and we'll go through it step by step.",

                    name + "That's completely fine. 🤔 Even IT professionals find some of this confusing at first. "
                        + "There are no silly questions here — ask anything and I'll explain it simply and clearly.",

                    name + "Confusion is the first step to understanding! 🤔 "
                        + "Cybersecurity concepts can be dense, but they all have logical explanations. "
                        + "What would you like me to clarify?"
                };
                return replies[_rand.Next(replies.Length)];
            }

            // --------------------------------------------------
            // CURIOUS / INTERESTED
            // --------------------------------------------------
            if (lower.Contains("curious") ||
                lower.Contains("interesting") ||
                lower.Contains("tell me more") ||
                lower.Contains("i want to know") ||
                lower.Contains("how does") ||
                lower.Contains("why does"))
            {
                string[] replies = {
                    name + "Great question — curiosity is exactly how cybersecurity awareness grows! 🔍 "
                        + "Let me give you a detailed breakdown.",

                    name + "Love that curiosity! 🔍 Understanding the 'how' and 'why' behind threats "
                        + "makes you significantly harder to fool. Here's what you need to know:",

                    name + "That's a smart thing to want to understand. 🔍 "
                        + "Knowing the mechanics behind attacks helps you spot them before they succeed."
                };
                return replies[_rand.Next(replies.Length)];
            }

            // No sentiment detected — return empty so no sentiment line is printed
            return "";
        }
    }
}