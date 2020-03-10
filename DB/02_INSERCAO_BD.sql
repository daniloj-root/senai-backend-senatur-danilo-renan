USE Senatur_Tarde

INSERT INTO TiposUsuarios (Titulo)
VALUES ('ADMINISTRADOR'),('CLIENTE')

INSERT INTO Usuarios (Email, Senha,IdTipoUsuario)
VALUES ('admin@admin.com','admin',1),('cliente@cliente.com','cliente',2)

INSERT INTO Pacotes (NomePacote,Descricao,DataIda,DataVolta,NomeCidade,Ativo,Valor)
VALUES ('SALVADOR - 5 DIAS/ 4 DIÁRIAS','O que não falta em Salvador são atrações. Prova disso são as praias, os museus e as construções seculares que dão um charme mais que especial à região. A cidade, sinônimo de alegria, também é conhecida pela efervescência cultural que a credenciou como um dos destinos mais procurados por turistas brasileiros e estrangeiros. O Pelourinho e o Elevador são alguns dos principais pontos de visitação','06/08/2020','10/08/2020','Salvador',1,854.00)
,(' RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DIÁRIAS',' O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe','28/03/2020','01/04/2020','Salvador',1826.00,1)
,('BONITO VIA CAMPO GRANDE - 1 PASSEIO - 5 DIAS / 4 DIÁRIAS','Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de águas cristalinas, além de cavernas inundadas, paredões rochosos e uma infinidade de peixes. Os aventureiros costumam render-se facilmente a esse destino regado por trilhas ecológicas, passeios de bote e descidas de rapel pelas inúmeras quedas de água da região','28/03/2020','01/04/2020','Bonito',1,1004.00)
