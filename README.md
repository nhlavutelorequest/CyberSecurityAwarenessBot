## My workflow screenshot for my chatbot 

<img width="1358" height="606" alt="workflow pass screenshot" src="https://github.com/user-attachments/assets/ce2354c4-a368-494a-8f9d-376004d70bdb" />

##  Demo Video
[Watch Here](YOUR_YOUTUBE_LINK)

##  CyberSecurity Awareness Chatbot (Part 1)

##  Project Overview
This project is a Cybersecurity Awareness Chatbot developed using C# in Visual Studio.  
The main goal of the chatbot is to educate users about common cybersecurity threats and how to stay safe online.

The chatbot interacts with users through a console-based interface and provides detailed explanations, real-world examples, and safety tips.



##  Objectives
- Educate users about cybersecurity topics
- Demonstrate programming concepts in C#
- Build an interactive chatbot system
- Implement voice and user interface enhancements



##  Features (Part 1)

###  User Interaction
- Accepts user input continuously
- Responds to questions based on keywords
- Personalised greeting using the user's name

###  Cybersecurity Education
The chatbot provides detailed information on:
- Password Safety
- Phishing Attacks
- Safe Browsing
- Malware
- Online Scams
- VPN (Virtual Private Network)
- Suspicious Links

Each response includes:
- Explanation of the concept
- Real-world examples
- Safety tips



###  Voice Integration
- Plays a `.wav` greeting sound when the program starts
- Implemented using `SoundPlayer` from `System.Media`
- Includes error handling for missing files



###  User Interface Enhancements
- ASCII logo displayed at startup
- Typing effect using `Thread.Sleep()` for better user experience
- Use of colours to distinguish user and bot messages



##  Project Structure

The project is organised into multiple classes:

- **Program.cs**  
  Entry point of the application. Starts the chatbot.

- **Chatbot.cs**  
  Controls the main flow of the program and user interaction.

- **ResponseManager.cs**  
  Processes user input and generates appropriate responses.

- **CyberSecurityTips.cs**  
  Stores detailed cybersecurity explanations.

- **VoiceGreeting.cs**  
  Handles audio playback for greeting.

- **UIHelper.cs**  
  Manages display elements like logo and typing effect.



##  Technologies Used
- C# (.NET)
- Visual Studio
- System.Media (for audio)
- Console Application



##  How the Program Works
1. The program starts in `Program.cs`
2. The chatbot is launched using the `Start()` method
3. A voice greeting is played
4. The logo is displayed
5. The user enters their name
6. The chatbot enters a loop to continuously:
   - Accept user input
   - Process it using `ResponseManager`
   - Display a response
7. The program ends when the user types `exit`



##  Key Concepts Demonstrated
- Object-Oriented Programming (OOP)
- Methods and Classes
- Loops (`while` loop)
- Conditional Statements (`if`)
- Arrays and Randomization
- File Handling
- Error Handling (try-catch)



##  Future Improvements (Part 2 & 3)
- Store user messages using arrays or lists
- Implement message searching and deletion
- Add more advanced chatbot logic
- Improve user interface (GUI)



##  Author
Malungani Request Nhlavutelo



##  Notes
This project is part of a Programming POE and focuses on building a functional and educational chatbot system.
