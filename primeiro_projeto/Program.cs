// Shirako Sounds
using System.Diagnostics;

string nome = "Shirako";
string sobrenome = "Takamoto";
string mensagemDeBoasVindas = "Bem aventurados são aqueles que escutão as sinfonias de "+nome+" "+sobrenome+".";
//List<string> listaDeBandas = new List<string>();
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
    const int maximoTentativasInvalidas = 3; // Limite de tentativas inválidas
    int contadorTentativasInvalidas = 0;     // Contador de tentativas inválidas

    while (true)
    {
        ExibirLogo();
        Console.WriteLine("\nDigite 1 para registrar uma banda.");
        Console.WriteLine("Digite 2 para mostrar lista de bandas registradas.");
        Console.WriteLine("Digite 3 para avaliar uma banda.");
        Console.WriteLine("Digite 4 para exibir a nota de uma banda.");
        Console.WriteLine("Digite 5 para exibir a média da banda.");
        Console.WriteLine("Digite 0 para sair");

        Console.WriteLine("\nDigite sua escolha:");
        string escolha = Console.ReadLine()!;

        try
        {
            int escolhaNumerica = int.Parse(escolha);

            switch (escolhaNumerica)
            {
                case 1:
                    ResgistrarBanda();
                    return;
                case 2:
                    MostrarBandasRegistradas();
                    return;
                case 3:
                    AvaliarBanda();
                    return;
                case 4:
                    ExibirNotasBanda();
                    return;
                case 5:
                    // Aqui você pode chamar uma função para exibir a média das notas da banda
                    return;
                case 0:
                    Console.WriteLine("Nós não customizamos, nós TEKUnizamos. Até outro dia.");
                    return;
                default:
                    Console.WriteLine("Opção inválida! Por favor, escolha uma opção entre 0 e 5.");
                    contadorTentativasInvalidas++;
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida! Por favor, digite um número entre as opções dispostas.");
            contadorTentativasInvalidas++;
        }

        // Verifica se excedeu o número máximo de tentativas inválidas
        if (contadorTentativasInvalidas >= maximoTentativasInvalidas)
        {
            Console.WriteLine("Número máximo de tentativas inválidas excedido. Essa é a minha sincera opnião...");
            Thread.Sleep(3000);
            AbrirLinkNoNavegador("https://www.youtube.com/watch?v=lL-cjXPZIHQ"); // Chama a função para abrir o link
            contadorTentativasInvalidas = 0; // Reinicia o contador
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"Tentativas inválidas: {contadorTentativasInvalidas}/{maximoTentativasInvalidas}");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}

// Função para abrir o link no navegador
void AbrirLinkNoNavegador(string url)
{
    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true // Garante que o link abra no navegador padrão
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao abrir o link: {ex.Message}");
    }
}


void ResgistrarBanda()
{
    Console.Clear();
    Console.WriteLine();
    Console.Write("Digite o nome da banda que deseja registrar: ");
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
        Console.WriteLine($"Nota que deseja atribuir para {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} designada para a {nomeDaBanda} foi registrada. ");
        Thread.Sleep(2000); 
        Console.Clear();
        ExibirOpcoesDoMenu();

    } else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

void ExibirNotasBanda()
{
    Console.Clear();
    Console.WriteLine("Notas da Banda");
    Console.Write("Digite o nome da banda que deseja consultar as notas: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notas = bandasRegistradas[nomeDaBanda];

        if (notas.Count > 0)
        {   
            notas.Sort();
            notas.Reverse();

            Console.WriteLine($"Notas atribuídas para {nomeDaBanda}:");
            foreach (int nota in notas)
            {
                Console.WriteLine($"¤ {nota}");
            }
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} ainda não possui notas atribuídas.");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
    }

    Console.Clear();
    ExibirOpcoesDoMenu();
}


ExibirOpcoesDoMenu();
