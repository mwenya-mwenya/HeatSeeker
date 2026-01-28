using Microsoft.Maui.Controls.Shapes;

namespace HeatSeeker
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        int failClicks = 0;
        int remainingClicks = 100;
        int bestScore = 0;

        Random random = new Random();
        private int winRow;
        private int winCol;



        public MainPage()
        {
            InitializeComponent();
            BuildButtonGrid();
        }

        private void BuildButtonGrid()
        {


            for (int i = 0; i < 10; i++)
                ButtonGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            for (int i = 0; i < 10; i++)
                ButtonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            // Add buttons to the grid

            winRow = random.Next(10);
            winCol = random.Next(10);
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    var button = new Button
                    {
                        Text = $"{row},{col}",
                        Margin = 2,
                        BackgroundColor = Colors.LightGray,
                        CornerRadius = 5
                    };

                    if (col == winCol && row == winRow)
                    {
                        button.Clicked += OnGridButtonClickedWin;

                    }
                    else
                    {
                        button.Clicked += OnGridButtonClicked;
                    }

                    ButtonGrid.Children.Add(button);
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                }
            }
        }

        private async void OnGridButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                var coords = btn.Text.Split(',');
                int row = int.Parse(coords[0]);
                int col = int.Parse(coords[1]);

                btn.Text = "XXX!";
                btn.BackgroundColor = GetProximityColor(row, col);
                btn.BorderColor = Colors.Gold;
                btn.BorderWidth = 3;

                // 🎯 Add bounce animation
                await btn.ScaleTo(0.8, 100, Easing.CubicOut);
                await btn.ScaleTo(1.2, 100, Easing.CubicIn);
                await btn.ScaleTo(1.0, 100, Easing.CubicOut);
                await btn.FadeTo(0.8, 100);

                btn.IsEnabled = false;

                failClicks += 1;
                remainingClicks -= 1;
                ScoreLabel.Text = $"Fails: {failClicks}   ||  Remaining: {remainingClicks}";
                GetProximityFeedback(row, col);
            }
        }

        private async void OnGridButtonClickedWin(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.Text = "WIN!";
                btn.BackgroundColor = Colors.Green;

                await btn.ScaleTo(1.1, 150, Easing.SinOut);
                await btn.ScaleTo(1.0, 150, Easing.SinIn);

                btn.IsEnabled = false;

                btn.BorderColor = Colors.Gold;
                btn.BorderWidth = 3;

                foreach (var child in ButtonGrid.Children)
                {
                    if (child is Button b)
                        b.IsEnabled = false;
                }
                if (remainingClicks > bestScore)
                {
                    bestScore = remainingClicks;
                }

                BestScoreLabel.Text = $"Your best score is: {bestScore}";

                bool playAgain = await DisplayAlert("Game Over", "Would you like to play again?", "Yes", "No");
                if (playAgain)
                {
                    reset();
                }
            }
        }

        private Color HslToRgb(double h, double s, double l)
        {
            double c = (1 - Math.Abs(2 * l - 1)) * s;
            double x = c * (1 - Math.Abs((h / 60) % 2 - 1));
            double m = l - c / 2;

            double r = 0, g = 0, b = 0;

            if (h < 60) { r = c; g = x; }
            else if (h < 120) { r = x; g = c; }
            else if (h < 180) { g = c; b = x; }
            else if (h < 240) { g = x; b = c; }
            else if (h < 300) { r = x; b = c; }
            else { r = c; b = x; }

            return new Color((float)(r + m), (float)(g + m), (float)(b + m));
        }

        private Color GetProximityColor(int row, int col)
        {
            int distance = Math.Abs(row - winRow) + Math.Abs(col - winCol);
            int maxDistance = (ButtonGrid.RowDefinitions.Count - 1) +
                  (ButtonGrid.ColumnDefinitions.Count - 1);// max Manhattan distance in 10x10 grid

            double t = 1.0 - (double)distance / maxDistance; // closer = higher t

            double hue = 240 - (240 * t); // 240 (blue) → 0 (red)
            double saturation = 0.8;
            double lightness = 0.5;

            return HslToRgb(hue, saturation, lightness);
        }
        private void GetProximityFeedback(int row, int col)
        {
            int distance = Math.Abs(row - winRow) + Math.Abs(col - winCol);

            if (distance <= 2)
            {
                tempratureGauge.Text = "🔥 You're very close!";
            }
            else if (distance <= 5)
            {
                tempratureGauge.Text = "🌡️ Getting warmer...";
            }
            else if (distance <= 10)
            {
                tempratureGauge.Text = "❄️ Still cold...";
            }
            else
            {
                tempratureGauge.Text = "🧊 Ice cold!";
            }

        }

        private void reset()
        {
            ButtonGrid.Children.Clear();
            ButtonGrid.RowDefinitions.Clear();
            ButtonGrid.ColumnDefinitions.Clear();
            BuildButtonGrid();
            failClicks = 0;
            remainingClicks = 100;
            ScoreLabel.Text = $"Fails: {failClicks}   ||  Remaining: {remainingClicks}";
            tempratureGauge.Text = "Not started 🤔";
        }
    }
}
