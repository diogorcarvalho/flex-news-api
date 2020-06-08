using FlexNewsApi.Models;
using System;

namespace FlexNewsApi.Data
{
  public class InitializeDB
  {
    public static void Initialize(DataContext context)
    {
      context.Authors.Add(new Author {
        Name = "Júlia Ramos de Carvalho"
      });

      context.Authors.Add(new Author {
        Name = "Laura Feijó Ramos de Carvalho"
      });

      context.Authors.Add(new Author {
        Name = "Diogo Ramos de Carvalho"
      });

      context.SaveChanges();
      
      context.Posts.Add(new Post{
        Title = "Uber, Lime e outras empresas suspendem serviços em cidades dos EUA",
        Text = "Empresas de aluguel de patinetes e bikes elétricas como Uber, Lime e Bird suspenderam os serviços em cidades americanas que concentram protestos contra racismo, após a morte de George Floyd em Minneapolis. A pausa das empresas acontece pouco tempo depois do início da retomada deste tipo de transporte, com o relaxamento do isolamento em algumas cidades.\nO objetivo é de prevenir danos, além de respeitar os horários do toque de recolher que passaram a ocorrer em alguns dos locais de protestos mais violentos. Já no começo desta semana a Uber suspendeu seus serviços em cidades como Los Angeles, Oakland, São Francisco e algumas regiões de Minneapolis.",
        AuthorId = 1,
        DateCreate = DateTime.UtcNow
      });

      context.Posts.Add(new Post{
        Title = "Exclusivo: WhatsApp busca executivo para comandar operações no Brasil",
        Text = "O WhatsApp aguarda algumas decisões de órgãos públicos brasileiros, como o julgamento do Supremo Tribunal Federal (STF) sobre a legalidade de bloquear o serviço no país e o projeto de lei contra as fake news em redes sociais e aplicativos de mensagens. Em meio a tudo isso, a empresa revelou que pretende contratar o primeiro executivo que comandará suas operações no Brasil.\nEm anúncio divulgado no LinkedIn, o WhatsApp indicou que a pessoa contratada para o cargo terá, entre outras funções, a missão de representar a plataforma entre “clientes seniores, formuladores de políticas governamentais, reguladores, defensores de direitos civis e de consumidores, e outras partes interessadas no país”.",
        AuthorId = 1,
        DateCreate = DateTime.UtcNow
      });

      context.Posts.Add(new Post{
        Title = "Google “Sabrina” com Android TV e controle remoto vazam em imagens",
        Text = "Os rumores sobre um lançamento de Chromecast com esteroides e que traz junto o Android TV aumentaram com um novo vazamento de imagens deste gadget, chamado internamente de Google Sabrina. O produto pode ser o sucessor direto do Chromecast Ultra, que é a versão 4K do dongle e que não foi lançado no Brasil.\nUm dos maiores empecilhos para o Chromecast ser ainda mais popular é a falta de controle remoto, o que obriga o usuário a conhecer profundamente aplicativos de smartphone, tablet ou suas versões para computador para poder controlar a reprodução de conteúdo que está na tela. Tudo pode mudar com o próximo dongle que boatos afirmam que o Google lançará em pouco tempo.",
        AuthorId = 2,
        DateCreate = DateTime.UtcNow
      });

      context.Posts.Add(new Post{
        Title = "Projeto quer proibir que operadoras vendam dados de localização",
        Text = "Um projeto de lei na Câmara dos Deputados quer proibir que operadoras de celular divulguem e vendam dados de deslocamento dos seus clientes. A medida interfere nas ferramentas utilizadas por governos e prefeituras para medir o índice de adesão à quarentena durante a pandemia do novo coronavírus, causador da COVID-19. A proposta surgiu após uma descoberta envolvendo os serviços de localização da Vivo.\nO projeto n° 2969/2020, de autoria de Nilto Tatto (PT-SP), propõe alterar a Lei Geral das Telecomunicações (LGT), que atualmente autoriza às prestadoras divulgarem a “informações agregadas sobre o uso de seus serviços, desde que elas não permitam a identificação, direta ou indireta, do usuário, ou a violação de sua intimidade”.",
        AuthorId = 2,
        DateCreate = DateTime.UtcNow
      });

      context.Posts.Add(new Post{
        Title = "PL das fake news retira trechos polêmicos antes da votação",
        Text = "O Senado deve votar nesta terça-feira (2) uma versão com modificações do projeto da Lei Brasileira de Liberdade, Responsabilidade e Transparência na Internet (PL 2630/2020). O texto ficou conhecido como PL das fake news, mas perdeu as medidas relacionadas ao combate à desinformação. Agora, a proposta se concentra em contas inautênticas e redes de distribuição artificial de conteúdo.\nO projeto também passou a proibir expressamente as plataformas de removerem conteúdo com base em seus artigos. Até então, o texto indicava que cabia a elas a adoção de medidas para proteger a sociedade contra a desinformação. O projeto ainda estimulava as redes sociais e os aplicativos de mensagens a usarem verificações de veículos independentes de checagem de fatos.",
        AuthorId = 3,
        DateCreate = DateTime.UtcNow
      });

      context.Posts.Add(new Post{
        Title = "Nubank chega a 25 milhões de clientes no cartão de crédito e conta digital",
        Text = "O Nubank lançou seu cartão de crédito sem anuidade há sete anos, em 2013, e agora tem 25 milhões de clientes: isso inclui também os usuários da conta digital (antes chamada NuConta), empréstimos e Rewards. A fintech continua sendo a sexta maior instituição financeira do Brasil, atrás apenas de bancos tradicionais como Bradesco e Itaú.\nOs 25 milhões de clientes do Nubank estão espalhados por todos os 5.570 municípios do Brasil. Os serviços da fintech atraíram 42 mil novas pessoas por dia durante o primeiro trimestre. Ela também está se expandindo para o México e Argentina.",
        AuthorId = 3,
        DateCreate = DateTime.UtcNow
      });

      context.SaveChanges();
    }
  }
}