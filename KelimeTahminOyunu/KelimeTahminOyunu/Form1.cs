using System.Windows.Forms;
using System;

public partial class Form1 : Form
{
    private string[] words = { "kalem", "defter", "kitap", "kırtasiye", "matematik", "fizik", "kimya", "tarih" };
    private string currentWord;
    private int remainingTime = 30;

    public Form1()
    {
        InitializeComponent();
        StartNewGame();
    }

    private void StartNewGame()
    {
        remainingTime = 30;
        currentWord = words[new Random().Next(words.Length)];
        wordTextBox.Text = currentWord;
        timerLabel.Text = remainingTime.ToString();
        timer1.Start();
    }

    private void CheckAnswer()
    {
        if (answerTextBox.Text.ToLower() == currentWord.ToLower())
        {
            MessageBox.Show("Tebrikler, doğru tahmin!");
            StartNewGame();
        }
        else
        {
            MessageBox.Show("Yanlış tahmin, tekrar dene!");
            answerTextBox.Text = "";
        }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        remainingTime--;
        timerLabel.Text = remainingTime.ToString();
        if (remainingTime == 0)
        {
            timer1.Stop();
            MessageBox.Show($"Süre doldu! Cevap: {currentWord}");
            StartNewGame();
        }
    }

    private void guessButton_Click(object sender, EventArgs e)
    {
        CheckAnswer();
    }

    private void nextButton_Click(object sender, EventArgs e)
    {
        StartNewGame();
    }
}
