import arcade

from views.setup import SetupView

SCREEN_WIDTH = 1000
SCREEN_HEIGHT = 800
SCREEN_TITLE = "Poor Pac Man"


def main():
    window = arcade.Window(SCREEN_WIDTH, SCREEN_HEIGHT, SCREEN_TITLE)
    start_view = SetupView()
    window.show_view(start_view)
    arcade.run()


if __name__ == "__main__":
    main()
