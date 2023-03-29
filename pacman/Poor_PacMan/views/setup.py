import arcade


class SetupView(arcade.View):
    def __init__(self):
        super().__init__()

    def on_show_view(self):
        arcade.set_background_color(arcade.color.DARK_BLUE_GRAY)

    def on_draw(self):
        from main import SCREEN_WIDTH
        self.clear()
        arcade.draw_text(f"Вітаємо у грі!",
                         SCREEN_WIDTH / 2,
                         600,
                         arcade.color.YELLOW_ORANGE,
                         font_size=32,
                         anchor_x="center")

        arcade.draw_text(f"Натисніть, щоб розпочати гру",
                         SCREEN_WIDTH / 2,
                         300,
                         arcade.color.BLACK,
                         font_size=28,
                         anchor_x="center")

    def on_mouse_press(self, _x, _y, _button, _modifiers):
        from views.game import GameView
        game_view = GameView()
        game_view.window.set_update_rate(1/4)
        game_view.setup()
        self.window.show_view(game_view)
