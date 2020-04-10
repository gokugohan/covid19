<p align="center">
<a href="https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1">
<img src="https://miro.medium.com/max/1400/1*Qy9HeVwrfnOTS3sptJ--hw.png" width="250px" alt="Asp.net Core"></a>
</p>

## Konaba projetu
Passatempo ba quarentena iha uma hodi halo webapp ne ho objetivo atualização de uso da tecnologia liliu iha .NetCore, design pattern, leafletjs
## Lokal deployment
- Atu hare mapa global ba covid19 basta loke index.html nebe sei renderiza no dados foti husi https://www.worldometers.info/coronavirus/ e https://corona-stats.online/
- Atu hare dados especificamente ba rai Timor-Leste nian, precisa iha Visual Studio IDE 2019 no iha dotnetcore versaun 3.1 installado e mos SqlServer bele mos usa MySql.
- Usa VS (dotnetcore) tamba hau precisa foti dados atu guarda iha base de dados para bele usa iha futuro ou bele mos usa ba dados estatísticos. Bele mos usa linguagem seluk juntamente ho framework ida nebe prefere.
- Obrigatório cria connection string iha appsettings.json
- Seleciona projeto Covid19.Web iha Package Console Manager(PCM) e executa comando "Update-Database -Context UserContext"
- Seleciona projeto Covid19.Entities iha PCM e executa comando "Update-Database -Context RepositoryContext"
- Selecion projeto Covid19.Web hanesan "Startup project"
- Ikus liu: Build Project + presiona Ctrl+F5 ou F5 para hare resultado

## Urls
- Covid19 Homepage <a href="http://covid19.chebre.net/" target="_blank">http://covid19.chebre.net/</a>
- Covid World Map <a href="http://covid-19-map.chebre.net/" target="_blank">http://covid-19-map.chebre.net/</a>

- Endpoint For quarantines: <a href="http://covid19.chebre.net/api/quarantines" target="_blank">http://covid19.chebre.net/api/quarantines</a>
- Endpoint For quarantines today: /api/quarantines/today
- Endpoint For quarantines today: /api/quarantines/today/{munipality}
- Endpoint For quarantines by date: /api/quarantines/{year}/{month}/{day}
- Endpoint For quarantines group by date: /api/quarantines/group_by_date
- Endpoint For quarantines group by municipalities: /api/quarantines/group_by_municipio

- Endpoint For cases: <a href="http://covid19.chebre.net/api/cases" target="_blank">http://covid19.chebre.net/api/cases</a>
- Endpoint For cases today: /api/cases/today
- Endpoint For cases by date: /api/cases/{year}/{month}/{day}
- Endpoint For cases group by date: /api/cases/group_by_date

NB: Ba Api Endpoint hau realmente kria project web api ketak, mas como iha problema ituan iha deployment, então hau duplica codigo mai iha web project hodi cria area ba api
## Screenshoots

-Homepage preview
![Capture](https://user-images.githubusercontent.com/4695463/78563090-62997980-7855-11ea-84f6-7d60bc0eb1ca.PNG)

-covid-19-map
![preview_1](https://user-images.githubusercontent.com/4695463/77768612-10eb3500-7086-11ea-91bc-8a4b6322a423.PNG)

