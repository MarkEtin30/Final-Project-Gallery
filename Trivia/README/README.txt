===============================================================================
                              Trivia Game README
===============================================================================

Welcome to the Trivia Game project! This application fetches trivia questions 
from the Open Trivia Database API and allows users to test their knowledge 
across various categories.

===============================================================================
Table of Contents
===============================================================================

1. Installation
2. Usage
3. Features
4. Technical Details
5. Contributing
6. License

===============================================================================
1. Installation
===============================================================================

Prerequisites:
- .NET Framework
- Visual Studio or any C# IDE

Steps:

1. Clone the repository: git clone https://github.com/yourusername/trivia-game.git

2. Open the project in Visual Studio:
- Launch Visual Studio.
- Navigate to File > Open > Project/Solution.
- Select the trivia-game.sln file from the cloned repository.

3. Build and run the project:
- Press F5 or go to Debug > Start Debugging.

===============================================================================
2. Usage
===============================================================================

1. Choose a trivia category:
- Click on one of the category buttons (History, Science, General Knowledge) 
  to load questions from that category.

2. Start the trivia game:
- Click "Start New Trivia Game" to begin answering questions.

3. Answer questions:
- Read each question and select one of the provided multiple-choice answers.
- Submit your answer by clicking the "Submit" button.

4. Score:
- Your score out of 10 is displayed after each question.
- At the end of 10 questions, your final score is shown.

===============================================================================
3. Features
===============================================================================

- Category Selection: Choose from History, Science, or General Knowledge 
categories.
- Interactive Gameplay: Answer trivia questions with immediate feedback.
- Score Tracking: Keep track of your score throughout the game.
- Randomized Questions: Questions and answer options are shuffled for each game 
session.

===============================================================================
4. Technical Details
===============================================================================

- API Integration: Utilizes the Open Trivia Database API (https://opentdb.com/) 
to fetch questions.
- Asynchronous Operations: Uses async methods to fetch data and update UI 
asynchronously.
- HTML Decoding: Handles decoding of HTML-encoded text in questions and answers.

===============================================================================
5. Contributing
===============================================================================

Contributions are welcome! If you'd like to contribute to this project, follow 
these steps:

1. Fork the repository.
2. Create a new branch (git checkout -b feature-branch).
3. Make your changes and test thoroughly.
4. Commit your changes (git commit -m 'Add feature').
5. Push to the branch (git push origin feature-branch).
6. Open a pull request on GitHub.

===============================================================================
6. License
===============================================================================

This project is licensed under the MIT License - see the LICENSE file for 
details.
