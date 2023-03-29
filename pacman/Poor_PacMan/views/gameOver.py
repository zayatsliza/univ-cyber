import arcade

from main import SCREEN_WIDTH


class GameOverView(arcade.View):
    def __init__(self, score):
        super().__init__()
        self.score = score

    def on_show_view(self):
        arcade.set_background_color(arcade.color.DARK_BLUE_GRAY)

    def on_draw(self):
        self.clear()
        """
        Draw "Game over" across the screen.
        """
        arcade.draw_text(f"Ви програли",
                         SCREEN_WIDTH / 2,
                         400,
                         arcade.color.WHITE,
                         font_size=54,
                         anchor_x="center")
        arcade.draw_text(f"Натисніть, щоб почати знову",
                         SCREEN_WIDTH / 2,
                         300,
                         arcade.color.WHITE,
                         font_size=24,
                         anchor_x="center")

        arcade.draw_text(f"Бали: {self.score}",
                         SCREEN_WIDTH / 2,
                         200,
                         arcade.color.BLACK,
                         font_size=15,
                         anchor_x="center")
        img = arcade.load_texture('images/gameOver.png')
        arcade.draw_texture_rectangle(500, 750, 1000, 500, img)

    def on_mouse_press(self, _x, _y, _button, _modifiers):
        from views.game import GameView
        game_view = GameView()
        game_view.window.set_update_rate(1/4)
        game_view.setup()
        self.window.show_view(game_view)
