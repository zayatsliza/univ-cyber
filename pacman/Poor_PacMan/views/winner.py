import arcade


class YouWonView(arcade.View):
    def __init__(self, score):
        super().__init__()
        self.score = score

    def on_show_view(self):
        arcade.set_background_color(arcade.color.DARK_BLUE_GRAY)

    def on_draw(self):
        from main import SCREEN_WIDTH
        self.clear()

        arcade.draw_text(f"Вітаю, переможцю!",
                         SCREEN_WIDTH / 2,
                         500,
                         arcade.color.YELLOW_ORANGE,
                         font_size=54,
                         anchor_x="center")

        arcade.draw_text(f"Твої бали: {self.score}",
                         SCREEN_WIDTH / 2,
                         300,
                         arcade.color.BLACK,
                         font_size=15,
                         anchor_x="center")

    def on_mouse_press(self, _x, _y, _button, _modifiers):
        from views.game import GameView
        game_view = GameView()
        game_view.window.set_update_rate(1/4)
        game_view.setup()
        self.window.show_view(game_view)
