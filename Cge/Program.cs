using System;

namespace ConSge;

public class TestGame : ConSge
{
    float posh = 0;
    float poswBall = 0;
    float poshBall = 0;
    public TestGame() : base("TestGame", 90, 30, 200, 200)
    {
    }

    protected override bool OnCreate()
    {
        return true;
    }

    protected override bool OnUpdate(float deltaTime)
    {
        ClearScreen();
        DrawText(20, 0, 0x4F, "Example game. Hold SPACEBAR to move the pixel");

        PongBall(20, 0, 0x4F, "Example game. Hold SPACEBAR to move the pixel");
      
        if (KeyHeld(38))
        {
            if (posh > 0)
                posh -= deltaTime * 20.0f;
            else
                posh = +1;
        }
        if (KeyHeld(40))
        {
            if (posh < Height)
                posh += deltaTime * 20.0f;
            else
                posh = Height - 1;
        }
        DrawPixel(0, (int)posh, 0x0E);
        return true;
    }

    private void PongBall(int x, int y, short color, string text)
    {
        for (var i = 0; i < text.Length; i++)
        {
            if (x + i >= Width) return;
            DrawPixelBall(x + i, y, color, text[i]);
        }
    }
}

public class Program
{
    static void Main()
    {
        var game = new TestGame();
        game.Run();
    }
}