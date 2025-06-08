# Ticket2Help

## Descrição do Projeto
Ticket2Help é uma plataforma interna para gestão de tickets de helpdesk, destinada a atender solicitações de serviços de hardware (HW) e software (SW) numa empresa. O sistema permite a geração, atendimento e acompanhamento de tickets, com funcionalidades específicas para técnicos e colaboradores, garantindo a gestão eficiente das solicitações.

---

## Funcionalidades

- **Gestão de utilizadores** com login e permissões diferenciadas.
- **Para técnicos de helpdesk/Admins:**
  - Atender tickets pendentes.
  - Gerar mapas estatísticos e dashboards.
- **Para utilizadores comuns:**
  - Criar tickets para serviços de hardware ou software.
  - Listar e acompanhar o estado dos seus tickets.

---

## Funcionamento

- Cada ticket é criado com número sequencial, data/hora automática, código do colaborador e estado inicial `porAtender`.
- Tickets de hardware requerem descrição de equipamento e avaria.
- Tickets de software requerem descrição do software e necessidade.
- Técnicos atualizam tickets com intervenção realizada, peças usadas (hardware), estado do atendimento (aberto, resolvido, não resolvido).
- Dashboard apresenta estatísticas como % tickets atendidos, % resolvidos/não resolvidos, média de tempo de atendimento, entre outros.

---

## Tecnologias Utilizadas

- **Interface:** WPF (Windows Presentation Foundation) com foco em acessibilidade.
- **Arquitetura:** 3 camadas (UI, BLL, DAL) seguindo padrão MVC.
- **Padrões de design:** MVC, Factory, Strategy, herança entre classes Ticket, HardwareTicket e SoftwareTicket.
- **Base de dados:** SQL Server.
- **Documentação:** Doxygen para geração automática da documentação em HTML.
- **Testes:** Testes unitários implementados para as classes Ticket.
- **Controle de versão:** GitHub para colaboração e gestão do código.

---

## Instalação e Uso

1. Clone este repositório:
2. Abra a solução no Visual Studio (versão recomendada).
3. Configure a ligação à base de dados SQL Server no ficheiro de configuração.
4. Compile e execute a aplicação WPF.
5. Faça login com as credenciais fornecidas para técnicos ou utilizadores comuns.
6. Utilize as funcionalidades conforme o perfil do utilizador.

---

## Estrutura do Projeto

- **UI/** - Projeto WPF para interface gráfica.
- **BLL/** - Camada de lógica de negócio, com classes e regras do sistema.
- **DAL/** - Acesso à base de dados SQL Server.
- **Tests/** - Testes unitários para validação das classes.
- **Docs/** - Documentação gerada pelo Doxygen.

---

## Equipa

- Guilherme Castro   — Função (Desenvolvimento da UI,BLL e testes)
- Guilherme Teixeira— Função (Implementação da BLL e DAL)
- Vitor Teixeira— Função (Desenvolvimento da UI e testes)

---

## Documentação e Referências

- Documentação gerada pelo Doxygen em `Ticket2Help/html/index.html`.
- Requisitos funcionais e análise no relatório do projeto.

---

## Contribuição

Contribuições são bem-vindas! Por favor, faça um fork do repositório, crie uma branch para a sua feature ou correção, e envie um pull request.

---

## Licença

Este projeto está licenciado sob a Licença MIT — veja o ficheiro LICENSE para detalhes.
