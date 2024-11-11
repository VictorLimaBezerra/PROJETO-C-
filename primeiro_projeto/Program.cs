// Shirako Sounds


string nome = "Shirako";
string sobrenome = "Takamoto";
string mensagemDeBoasVindas = "Bem aventurados são aqueles que escutão as sinfonias de "+nome+" "+sobrenome+".";
List<string> listaDeBandas = new List<string>();
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();


void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗██╗░░██╗██╗██████╗░░█████╗░██╗░░██╗░█████╗░
██╔════╝██║░░██║██║██╔══██╗██╔══██╗██║░██╔╝██╔══██╗
╚█████╗░███████║██║██████╔╝███████║█████═╝░██║░░██║
░╚═══██╗██╔══██║██║██╔══██╗██╔══██║██╔═██╗░██║░░██║
██████╔╝██║░░██║██║██║░░██║██║░░██║██║░╚██╗╚█████╔╝
╚═════╝░╚═╝░░╚═╝╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░

████████╗░█████╗░██╗░░██╗░█████╗░███╗░░░███╗░█████╗░████████╗░█████╗░
╚══██╔══╝██╔══██╗██║░██╔╝██╔══██╗████╗░████║██╔══██╗╚══██╔══╝██╔══██╗
░░░██║░░░███████║█████═╝░███████║██╔████╔██║██║░░██║░░░██║░░░██║░░██║
░░░██║░░░██╔══██║██╔═██╗░██╔══██║██║╚██╔╝██║██║░░██║░░░██║░░░██║░░██║
░░░██║░░░██║░░██║██║░╚██╗██║░░██║██║░╚═╝░██║╚█████╔╝░░░██║░░░╚█████╔╝
░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░░░░╚═╝░╚════╝░░░░╚═╝░░░░╚════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
    
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda.");
    Console.WriteLine("Digite 2 para mostrar lista de bandas registradas.");
    Console.WriteLine("Digite 3 para avaliar uma banda.");
    Console.WriteLine("Digite 4 para exibir a média da banda");
    Console.WriteLine("Digite 5 para sair");

    Console.WriteLine("\nDigite sua escolha.");
    string escolha = Console.ReadLine()!;
    int escolhaNumerica = int.Parse(escolha);

    switch (escolhaNumerica)
    {
        case 1: ResgistrarBanda();
            //Console.WriteLine("Opção selecionada: " + escolhaNumerica + ".");
            break;
        case 2: MostrarBandasRegistradas();
            //Console.WriteLine("Opção selecionada: " + escolhaNumerica + ".");
            break;
        case 3: AvaliarBanda();
            //Console.WriteLine("Opção selecionada: " + escolhaNumerica + ".");
            break;
        case 4:
            //Console.WriteLine("Opção selecionada: " + escolhaNumerica + ".");
            break;
        case 5:
           //Console.WriteLine("Opção selecionada: " + escolhaNumerica + ".");
             Console.WriteLine("Nós não customizamos, nós TEKUnizamos. Até outro dia.");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }

}


void ResgistrarBanda()
{
    Console.Clear();
    Console.WriteLine();
    Console.Write("DIgite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep( 2000 );
    Console.Clear();
    ExibirOpcoesDoMenu();
}


void MostrarBandasRegistradas()
{
    Console.Clear();
    Console.WriteLine("Bandas registradas até o momento:\n");

    foreach ( string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}


void AvaliarBanda()
{
    Console.Clear();
    Console.WriteLine("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if(bandasRegistradas.ContainsKey(nomeDaBanda) )
    {

    } else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }


}


ExibirOpcoesDoMenu();
