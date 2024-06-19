# PongGame

Welcome to the PongGame project! This is a simple Pong game implemented using WPF in C#. The game features two paddles and a ball, with the goal being to score points by getting the ball past your opponent's paddle.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Contributing](#contributing)
- [License](#license)

## Installation

### Prerequisites

- .NET SDK
- Visual Studio or any other C# IDE

### Steps

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/pong-game.git
    ```

2. Open the project in Visual Studio:
    - Open Visual Studio.
    - Go to `File > Open > Project/Solution`.
    - Navigate to the cloned repository and open `PongGame.sln`.

3. Build the project:
    - Go to `Build > Build Solution` or press `Ctrl+Shift+B`.

## Usage

1. Start the application:
    - Press `F5` or go to `Debug > Start Debugging`.

2. Play the game:
    - Use `W` and `S` keys to move the left paddle up and down.
    - Use the `Up` and `Down` arrow keys to move the right paddle up and down.
    - The ball will start moving automatically once the game begins.
    - Score points by getting the ball past your opponent's paddle. The first player to score 10 points wins the game.

## Features

- **Paddle Movement**: Control the paddles using keyboard keys.
- **Ball Movement**: The ball moves and bounces off walls and paddles.
- **Scoring**: Scores are tracked for both players and displayed on the screen.
- **Divider**: A visual divider separates the two halves of the playing area.

## Game Logic

1. **Initialization**:
    - Paddles, ball, and divider are created and added to the game canvas.
    - The game timer is started to control the game loop.

2. **Game Loop**:
    - The ball moves based on its speed.
    - Collision detection for walls and paddles adjusts the ball's direction.
    - Scores are updated when the ball goes out of bounds.

3. **Paddle Control**:
    - Players can move their paddles up and down using the specified keys.

4. **Score Display**:
    - Player scores are displayed and updated in real-time.

## Contributing

Contributions are welcome! If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add some feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Built using WPF and C#.

---

If you have any questions or need further assistance, feel free to contact the project maintainer or create an issue in the repository.
