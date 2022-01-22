rollback

select @@TRANCOUNT

begin tran
select * from dbo.Cursos

INSERT INTO Cursos(id, titulo, MaxTempoDia) VALUES ('1', 'Sistemas de Informa��o', 18)
INSERT INTO Cursos(id, titulo, MaxTempoDia) VALUES ('2', 'Engenharia El�trica', 10)

select * from dbo.Professores

INSERT INTO Professores(id, Nome) VALUES ('1', 'FRANCISCO')
INSERT INTO Professores(id, Nome) VALUES ('2', 'ANA JULIA')
INSERT INTO Professores(id, Nome) VALUES ('3', 'GILSON')
INSERT INTO Professores(id, Nome) VALUES ('4', 'ROSANA')
INSERT INTO Professores(id, Nome) VALUES ('5', 'JEAN')
INSERT INTO Professores(id, Nome) VALUES ('6', 'GEORGE')
INSERT INTO Professores(id, Nome) VALUES ('7', 'JISLAINE')
INSERT INTO Professores(id, Nome) VALUES ('8', 'CRIS')
INSERT INTO Professores(id, Nome) VALUES ('9', 'LAURO')
INSERT INTO Professores(id, Nome) VALUES ('10', 'TEO')
INSERT INTO Professores(id, Nome) VALUES ('11', 'JONATAS')
INSERT INTO Professores(id, Nome) VALUES ('12', 'M�RIO')

select * from dbo.Locais

INSERT INTO Locais(id, Nome) VALUES ('1', 'Lab. 04 COINF')
INSERT INTO Locais(id, Nome) VALUES ('2', '08-BL03-S')
INSERT INTO Locais(id, Nome) VALUES ('3', 'Lab 06 -COINF-i')
INSERT INTO Locais(id, Nome) VALUES ('4', '11-COINF')
INSERT INTO Locais(id, Nome) VALUES ('5', 'Lab 06 -COINF-s')
INSERT INTO Locais(id, Nome) VALUES ('6', 'Lab 01')
INSERT INTO Locais(id, Nome) VALUES ('7', 'Lab 02 -COINF')
INSERT INTO Locais(id, Nome) VALUES ('8', 'Lab 03')

select * from Semestres

insert into Semestres (Id, Descricao) values (99, 'Teste')


Select * from Usuarios

SET IDENTITY_INSERT Usuarios ON
insert into Usuarios (id, CPF, CursoId, Matricula, Nome) values ('88', '00000000000', 1, '123456', 'Demo' )
SET IDENTITY_INSERT Usuarios OFF

select * from dbo.Disciplinas

INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('1', 'Matem�tica Discreta', 4, 0, 1, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('2', 'L�gica Matem�tica', 4, 0, 1, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('3', 'Introdu��o � Administra��o', 4, 0, 1, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('4', 'Introdu��o � Computa��o', 10, 4, 1, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('5', 'Fundamentos de Programa��o', 8, 0, 1, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('6', 'Portugu�s Instrumental', 3, 0, 1, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('7', 'C�lculo I', 6, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('8', 'Fundamentos de Sistema de Informa��o', 4, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('9', 'Arquitetura e Organiza��o de Computadores', 4, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('10', 'Paradigma Orientado a Objetos', 6, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('11', 'Educa��o e Diversidade', 3, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('12', 'Ingl�s Instrumental', 2, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('13', 'Inform�tica �tica e Sociedade', 2, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('14', 'Metodologia Cient�fica', 3, 0, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('15', 'Modelagem de Dados', 4, 25, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('16', 'Sistemas Operacionais', 4, 0, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('17', 'An�lise Orientada a Objetos', 4, 0, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('18', 'Algoritmos e Estrutura de Dados I', 6, 0, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('19', 'Engenharia de Software', 4, 25, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('20', 'Probabilidade e Estat�stica', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('21', 'Projeto de Banco de Dados', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('22', 'Redes de Computadores', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('23', 'Padr�es de Projeto e Arquitetura de Software', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('24', 'Algoritmos e Estrutura de Dados II', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('25', 'Qualidade de Software', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('26', 'Projeto Integrador I', 2, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('27', 'Adm de Banco de Dados', 4, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('28', 'Lab de Redes de Computadores', 4, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('29', 'Programa��o Web I', 4, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('30', 'Ger�ncia de Projetos', 4, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('31', 'Teste de Software', 2, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('32', 'Modelagem de processo de Neg�cio', 2, 90, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('33', 'Sistema de Apoio a Decis�o', 4, 0, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('34', 'Sistemas Distribu�dos', 2, 0, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('35', 'Programa��o Web II', 6, 0, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('36', 'Governan�a de TI', 4, 0, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('37', 'Indtrodu��o Humano Computador', 2, 0, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('38', 'Projeto e An�lise de Algoritmos', 2, 0, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('39', 'TCC I', 1, 127, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('40', 'Seguran�a e Auditoria', 1, 0, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('41', 'Projeto Integrador II', 4, 0, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('42', 'Orienta��o a Est�gio', 2, 70, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('43', 'Programa��o Para Dispositivos M�veis', 4, 0, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('44', 'Empreendedorismo', 4, 0, 8, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('45', 'TCC II', 1, 0, 8, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('46', 'Computa��o Inteligente', 4, 0, 8, 2015, 1, 99, '88')

select * from dbo.PreRequisitoDisciplina

INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('9', '4')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('10', '5')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('16', '9')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('17', '10')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('18', '10')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('21', '15')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('22', '9')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('23', '10')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('24', '18')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('25', '19')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('26', '15')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('26', '17')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('26', '19')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('27', '21')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('28', '22')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('29', '23')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('30', '19')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('31', '25')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('33', '27')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('34', '28')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('34', '16')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('35', '29')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('36', '30')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('37', '19')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('38', '24')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('40', '16')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('40', '29')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('41', '27')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('41', '29')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('41', '31')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('41', '30')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('41', '37')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('43', '10')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('45', '39')
INSERT INTO dbo.PreRequisitoDisciplina(DisciplinaId, RequisitoDisciplinaId) VALUES ('46', '24')

select Disciplinas.Nome as disciplina, RequisitoDisciplinaId from dbo.PreRequisitoDisciplina left join dbo.Disciplinas on DisciplinaId = Disciplinas.Id

commit