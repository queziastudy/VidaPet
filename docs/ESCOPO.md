# Escopo da 1ª entrega — Sistema de Agendamento VidaPet (TP1)

## Objetivo
Levantar e documentar os requisitos e os casos de uso da Clínica Veterinária VidaPet e desenvolver um primeiro programa standalone em C# para iniciar o cadastro de animais e veterinários e simular o agendamento de consultas.

## Dentro (Must)
- **RF01 — Cadastrar veterinário:** informar e validar nome e CRMV.
- **RF02 — Cadastrar animal:** informar e validar nome, espécie (cão ou gato), idade, nome do tutor e telefone do tutor.
- **RF03 — Agendar consulta (versão inicial):** verificar a existência de animal e veterinário cadastrados; solicitar CRMV, animal, data e horário; validar identificação, formato da data/hora e impedir datas anteriores à atual; simular o registro do agendamento.
- **Documentação:** levantamento dos requisitos funcionais (RF01 a RF06), não funcionais (RNF01 a RNF04) e regras de negócio (RN01 a RN06); especificação dos casos de uso (UC01 a UC06) com fluxos principais e alternativos; diagrama UML de casos de uso.
- **Ambiente e protótipo:** trilha C# com .NET 10 SDK (LTS), menu inicial e programa standalone simples com tipos, operadores e estruturas de controle, sem introduzir uma arquitetura orientada a objetos nesta etapa.

## Fora desta entrega (Won't)
- **RF04 — Cancelar consulta:** alterar a situação de uma consulta agendada para cancelada.
- **RF05 — Consultar agenda do dia:** exibir os atendimentos diários de cada veterinário.
- **RF06 — Registrar consulta realizada:** registrar observações e concluir atendimentos.
- **Validações completas do RF03:** duração fixa de 30 minutos (RN01), atendimento apenas de segunda a sexta, das 8h às 18h (RN02), e bloqueio de horários sobrepostos para o mesmo veterinário (RN03).
- **Infraestrutura avançada:** persistência em banco de dados, API web, autenticação e implementação completa do histórico de consultas.

## Justificativa
- **Valor e dependência:** RF01 e RF02 fornecem os cadastros necessários para o RF03, que representa o fluxo central do sistema: agendar consultas.
- **Risco e complexidade:** as regras de duração, expediente e conflitos de horário exigem controles adicionais de agenda; por isso, serão implementadas após a estrutura inicial.
- **Esforço e prazo:** o TP1 prioriza análise, modelagem, configuração do ambiente e uso de fundamentos da linguagem C#, sem exigir ainda um sistema completo com orientação a objetos, banco de dados, API ou autenticação.
- **Evolução planejada:** os seis casos de uso e as seis regras de negócio já foram documentados como referência para as próximas entregas, mesmo quando ainda não estão implementados.

## Pronto quando
- O documento de requisitos identifica RF01 a RF06, RNF01 a RNF04 e RN01 a RN06.
- O diagrama UML representa os atores **Recepcionista** e **Veterinário**, e os seis casos de uso possuem fluxos principais e alternativos documentados.
- O programa standalone em C# compila e executa no ambiente .NET 10 configurado.
- Pelo menu, é possível informar e validar os dados de um veterinário e de um animal.
- Ao escolher agendar uma consulta, o programa verifica se há cadastros disponíveis, solicita os dados do agendamento, rejeita datas passadas e simula o registro quando as verificações iniciais são atendidas.

> **Observação:** nesta entrega, o agendamento ainda é uma simulação, sem persistência de dados ou aplicação integral das regras de disponibilidade. Os critérios acima descrevem o escopo e a verificação esperada do TP1, não uma certificação independente de todos os testes do código.
