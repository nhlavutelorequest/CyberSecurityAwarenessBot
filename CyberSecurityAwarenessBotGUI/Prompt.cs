using System;
using System.Windows.Forms;

namespace CyberSecurityAwarenessBotGUI
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 700,
                Height = 180,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label()
            {
                Left = 20,
                Top = 20,
                Width = 340,
                Text = text
            };

            TextBox inputBox = new TextBox()
            {
                Left = 20,
                Top = 50,
                Width = 340
            };

            Button confirmation = new Button()
            {
                Text = "OK",
                Left = 140,
                Width = 100,
                Top = 90
            };

            confirmation.Click += (sender, e) =>
            {
                prompt.Close();
            };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);

            prompt.ShowDialog();

            return inputBox.Text;
        }
    }
}