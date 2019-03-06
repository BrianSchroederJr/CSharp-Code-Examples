Imports Example___CarLibrary

Module Module1

    Sub Main()
        Console.WriteLine("***** VB CarLibrary Client App *****")
        Dim myMiniVan As New MiniVan()
        myMiniVan.TurboBoost()
        Dim mySportsCar As New SportsCar()
        mySportsCar.TurboBoost()
        Console.ReadLine()
    End Sub

End Module
