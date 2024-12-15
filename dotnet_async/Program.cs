﻿#region Programacao Assincrona
//object chave = new object();
//Task<string> conteudoTask;
//lock(chave)
//{
//    conteudoTask = Task.Run(() => File.ReadAllTextAsync("voos.txt"));
//}

//async Task LerArquivoAsync(CancellationToken token)
//{
//    try
//    {
//        await Task.Delay(new Random().Next(300, 8000));
//        token.ThrowIfCancellationRequested();
//        Console.WriteLine($"Conteúdo: \n{conteudoTask.Result}");

//    }
//    catch (OperationCanceledException ex)
//    {
//       Console.WriteLine($"Tarefa cancelada: {ex.Message}");
//    }
//    catch (AggregateException ex)
//    {
//        Console.WriteLine($"Aconteceu o erro: {ex.InnerException.Message}");
//    }

//}

//async Task ExibirRelatorioAsync(CancellationToken token)
//{
//	try
//	{
//        Console.WriteLine("Executando relatório de compra de passagens!");
//        await Task.Delay(new Random().Next(300, 8000));
//        token.ThrowIfCancellationRequested();
//    }
//	catch(OperationCanceledException ex)
//	{

//        Console.WriteLine($"Tarefa cancelada: {ex.Message}");
//	}

//}

//CancellationTokenSource tokenDeCancelamento = new CancellationTokenSource();

//Task tarefa= Task.WhenAll(LerArquivoAsync(tokenDeCancelamento.Token), ExibirRelatorioAsync(tokenDeCancelamento.Token));

//await Task.Delay(1000).ContinueWith(_ => tokenDeCancelamento.Cancel());

//Console.WriteLine("Outras operações.");
//Console.ReadKey();
#endregion

using dotnet_async.Client;

var client = new JornadaMilhasClient(new JornadaMilhasClientFactory().CreateClient());

async Task ProcessarConsultarDeVoosAsync()
{
    try
    {
        CancellationTokenSource tokenSource = new CancellationTokenSource();

        tokenSource.Cancel();

        var voos = await client.ConsultarVoosAsync(tokenSource.Token);

        foreach (var voo in voos)
        {
            Console.WriteLine(voo);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Tarefa cancelada: {ex.Message}");
    }
    
}

await  ProcessarConsultarDeVoosAsync();