 string tamanho, valet, lavagem;
        int permanencia;
        decimal valorEstacionamento = 0, valorValet = 0, valorLavagem = 0, total = 0;

        Console.WriteLine("--- Estacionamento ---");

        Console.Write("Tamanho do veículo (P/G).....: ");
        tamanho = Console.ReadLine()!.Trim().ToUpper();
        if (tamanho != "P" && tamanho != "G")
        {
            Console.WriteLine("Tamanho inválido. Use apenas P ou G.");
            return;
        }

        Console.Write("Tempo de permanência (min)...: ");
        if (!int.TryParse(Console.ReadLine(), out permanencia) || permanencia <= 0 || permanencia > 720)
        {
            Console.WriteLine("Tempo inválido. Deve ser entre 1 e 720 minutos.");
            return;
        }

        Console.Write("Serviço de valet (S/N).......: ");
        valet = Console.ReadLine()!.Trim().ToUpper();
        if (valet != "S" && valet != "N")
        {
            Console.WriteLine("Entrada inválida para valet. Use S ou N.");
            return;
        }

        Console.Write("Serviço de lavagem (S/N).....: ");
        lavagem = Console.ReadLine()!.Trim().ToUpper();
        if (lavagem != "S" && lavagem != "N")
        {
            Console.WriteLine("Entrada inválida para lavagem. Use S ou N.");
            return;
        }
        
        int tempoCobrado = permanencia <= 65 ? 60 : permanencia;

        if (tempoCobrado >= 300)
        {
            valorEstacionamento = (tamanho == "G") ? 80 : 50;
        }
        else
        {
            valorEstacionamento = 20; // Primeira hora
            int horasAdicionais = (int)Math.Ceiling((tempoCobrado - 60) / 60.0);
            if (tamanho == "G")
                valorEstacionamento += horasAdicionais * 20;
            else
                valorEstacionamento += horasAdicionais * 10;
        }


        if (valet == "S")
        {
            valorValet = valorEstacionamento * 0.20m;
        }


        if (lavagem == "S")
        {
            valorLavagem = (tamanho == "G") ? 100 : 50;
        }


        total = valorEstacionamento + valorValet + valorLavagem;

        Console.WriteLine();
        Console.WriteLine($"Estacionamento..:       R$ {valorEstacionamento,6:0.00}");
        Console.WriteLine($"Valet...........:       R$ {valorValet,6:0.00}");
        Console.WriteLine($"Lavagem.........:       R$ {valorLavagem,6:0.00}");
        Console.WriteLine($"-------------------------------");
        Console.WriteLine($"Total...........:       R$ {total,6:0.00}");
