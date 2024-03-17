// See https://aka.ms/new-console-template for more information

using ConsoleTestes.Programas;
using System;
using System.Diagnostics;

Main();

 void Main()
{

    MenuPrograma.menu();
}

public class MenuPrograma()
{
    static string version = "20240316.Build.1"; // 0000 - ano 00 - mes 00 - dia .Build. - info da build 0 - numero da builda da versao
    public static void menu()
    {
        //Console.WriteLine("Hello World! existem estes programas \n Programa[1]  Programa[2]");
        Console.Write(
            "versão: " + MenuPrograma.version + "\n" +
            "==========ConsoleTestes========== \n" +
            " Programas/Desafios disponíveis \n" +
            "Programa - ApenasTeste[1]  Programa - Calc Operadores Básicos[2] \n=>"
            );
        string ret = Console.ReadLine();

        switch (ret)
        {
            case "1":
                Console.Write("Inciando programa ApenasTeste... \nDigite uma mensagem para ser exibida!\n=>");
                string msg = Console.ReadLine();
                ApenasTeste.teste(msg);
                break;
            case "2":
                CalcOperadoresBasicos.menuPrograma();
                break;
            default:
                Console.WriteLine("Nenhum programa existe com esta definição!");
                break;
        }
    }
}