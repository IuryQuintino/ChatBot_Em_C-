using System;
using System.Collections.Generic;
using System.Linq; // Necessário para métodos como Where e ToArray

namespace ChatbotConsole
{
    class Program
    {
        // Variável estática para o vocabulário, acessível por toda a classe
        static Dictionary<string, string[]> vocabulario = new Dictionary<string, string[]>()
        {
            // TÓPICO 1: SAUDAÇÕES
            {
                "ola", new string[] {
                    "Olá! Como posso te ajudar hoje?",
                    "Oi, que bom te ver! O que você gostaria de conversar?",
                    "E aí! Tudo bem por aí?",
                    "Saudações! É um prazer conversar com você."
                }
            },
            
            // TÓPICO 2: INFORMAÇÕES PESSOAIS (ID E NOME)
            {
                "idade", new string[] {
                    "Eu não tenho uma idade, sou um programa de computador!",
                    "A minha idade é contada em linhas de código, hehe.",
                    "Sou bem jovem, mas já sei de muita coisa.",
                    "Minha idade é a mesma da última vez que fui compilado!"
                }
            },
            {
                "nome", new string[] {
                    "Eu sou o Chatbot Simples, seu assistente de console!",
                    "Pode me chamar de Bot. Qual é o seu nome?",
                    "Não tenho um nome formal, sou uma IA em treinamento."
                }
            },

            // TÓPICO 3: ASSUNTOS GERAIS
            {
                "clima", new string[] {
                    "Não tenho acesso ao clima, mas espero que esteja um dia lindo!",
                    "O clima da minha sala de servidores está ótimo. E o seu?",
                    "Você pode procurar o clima na internet 😉.",
                    "Aqui só faz calor de processador, mas lá fora deve estar agradável!"
                }
            },
            {
                "gosta", new string[] {
                    "Eu gosto muito de processar strings e rodar em loops!",
                    "Adoro quando você usa a palavra 'ola' de novo, rs.",
                    "Minha atividade favorita é mapear chaves e valores no meu Dictionary."
                }
            },
            
            // TÓPICO 4: PROGRAMAÇÃO E C#
            {
                "programar", new string[] {
                    "Programar em C# é muito divertido! Estamos usando .NET, sabia?",
                    "Estou sendo executado em C#. É uma linguagem poderosa e elegante!",
                    "Você sabia que o C# é muito usado para jogos (Unity) e aplicativos web (ASP.NET)?"
                }
            },
            {
                "c#", new string[] {
                    "C# é a minha linguagem-mãe! Gosto muito de como o `Dictionary` funciona.",
                    "C# é uma linguagem orientada a objetos da Microsoft.",
                    "A sintaxe do C# é clara e robusta, o que facilita o desenvolvimento."
                }
            },
            
            // TÓPICO 5: AJUDA
            {
                "ajuda", new string[] {
                    "Posso te ajudar com informações sobre 'ola', 'idade', 'clima' e 'programar'.",
                    "Em que tipo de ajuda você está pensando?",
                    "Se for sobre o meu código, tente perguntar sobre 'c#' ou 'programar'!"
                }
            }
        };

        // Lista de mensagens padrão/fallback para quando nenhuma palavra-chave for encontrada
        static string[] mensagensPadrao = new string[]
        {
            "Desculpe, não entendi. Tente usar as palavras: 'ola', 'idade', 'clima', 'nome' ou 'programar'.",
            "Hmm, isso é um pouco complexo para mim. Pode reformular a pergunta?",
            "Não consegui processar sua solicitação. Eu sou um chatbot bem simples, viu?",
            "Meus desenvolvedores ainda estão me treinando para responder isso.",
            "Que interessante! Mas não sei o que dizer sobre isso ainda.",
            "Sinto muito, não tenho essa informação no meu vocabulário atual.",
            "Pode me fazer uma pergunta sobre C#?",
            "Talvez se você disser 'ajuda', eu possa te orientar melhor.",
            "Variavel é armazenar dados na memória do computador."
        };

        // Objeto Random criado uma única vez para selecionar respostas aleatórias
        static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine(" Olá! Sou um chatbot . Digite algo ou 'sair' para encerrar.");

            // Loop principal que mantém o chat rodando
            while (true)
            {
                Console.Write("\nVocê: ");
                string entradaUsuario = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entradaUsuario) || entradaUsuario.ToLower() == "sair")
                {
                    Console.WriteLine("Tchau! Volte sempre!");
                    break;
                }

                // Chamar a função que processa e responde
                string resposta = GerarResposta(entradaUsuario);
                Console.WriteLine($" {resposta}");
            }
        }

        // Função responsável por processar a entrada do usuário e gerar uma resposta
        static string GerarResposta(string entrada)
        {
            // 1. Limpa a entrada: remove pontuações, transforma para minúsculas e divide em palavras.
            string entradaLimpa = new string(entrada.Where(c => !char.IsPunctuation(c)).ToArray());

            // Divide a string limpa em palavras, removendo entradas vazias
            string[] palavras = entradaLimpa.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // 2. Procura por palavras-chave
            foreach (string palavra in palavras)
            {
                // Verifica se o dicionário contém a palavra-chave
                if (vocabulario.ContainsKey(palavra))
                {
                    // A palavra-chave foi encontrada!
                    string[] possiveisRespostas = vocabulario[palavra];

                    // Seleciona uma resposta aleatória do array de respostas
                    int indice = rand.Next(possiveisRespostas.Length);
                    return possiveisRespostas[indice];
                }
            }

            // 3. Resposta Padrão (Fallback) se nenhuma palavra-chave for encontrada
            // Seleciona aleatoriamente uma das mensagens padrão
            int indicePadrao = rand.Next(mensagensPadrao.Length);
            return mensagensPadrao[indicePadrao];
        }
    }
}