using McLovin_04.Modelos;
using System.Text.Json;
using McLovin_04.Filtros;

using (HttpClient client = new HttpClient())
{



    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;


        bool executar = true;
        while (executar)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Exibir detalhes da primeira música");
            Console.WriteLine("2 - Filtrar músicas em C#");
            Console.WriteLine("3 - Filtrar todos os gêneros musicais");
            Console.WriteLine("4 - Filtrar artistas por gênero musical");
            Console.WriteLine("5 - Filtrar músicas por artista");
            Console.WriteLine("6 - Exibir lista de artistas ordenados");
            Console.WriteLine("7 - Adicionar música às favoritas e exibir favoritas");
            Console.WriteLine("8 - Gerar arquivo JSON das músicas favoritas");
            Console.WriteLine("0 - Sair");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    musicas[0].ExibirDetalhesMusica();
                    break;

                case "2":
                    Linq.FiltrarMusicasEmCSharp(musicas);
                    break;

                case "3":
                    Linq.FiltrarTodosOsGenerosMusicais(musicas);
                    break;

                case "4":
                    Console.WriteLine("Digite o gênero musical:");
                    string genero = Console.ReadLine();
                    Linq.FiltrarArtistasGeneros(musicas, genero);
                    break;

                case "5":
                    Console.WriteLine("Digite o nome do artista:");
                    string artista = Console.ReadLine();
                    Linq.FiltrarMusicas(musicas, artista);
                    break;

                case "6":
                    LinqOrdem.ExibirListaDeArtistasOrdenados(musicas);
                    break;

                case "7":
                    var musicasPreferidas = new MusicasPreferidas("Drafes");

                    musicasPreferidas.AdicionarMusicasFav(musicas[1]);
                    musicasPreferidas.AdicionarMusicasFav(musicas[842]);
                    musicasPreferidas.AdicionarMusicasFav(musicas[48]);
                    musicasPreferidas.AdicionarMusicasFav(musicas[10]);
                    musicasPreferidas.AdicionarMusicasFav(musicas[99]);

                    musicasPreferidas.ExibirMusicasFavoritas();
                    break;

                case "8":
                    var favoritas = new MusicasPreferidas("Drafes");

                    favoritas.AdicionarMusicasFav(musicas[1]);
                    favoritas.AdicionarMusicasFav(musicas[842]);
                    favoritas.AdicionarMusicasFav(musicas[48]);
                    favoritas.AdicionarMusicasFav(musicas[10]);
                    favoritas.AdicionarMusicasFav(musicas[99]);

                    favoritas.GerarArquivoJson();
                    break;

                case "0":
                    executar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

            Console.WriteLine();
        }

    }
    catch (Exception ex) 
    {
        Console.WriteLine($"Temos um problema : {ex.Message}");
    }
}