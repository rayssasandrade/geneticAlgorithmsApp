rollback

select @@TRANCOUNT

begin tran
select * from dbo.Cursos

INSERT INTO Cursos(id, titulo, MaxTempoDia) VALUES ('1', 'Sistemas de Informação', 18)
INSERT INTO Cursos(id, titulo, MaxTempoDia) VALUES ('2', 'Engenharia Elétrica', 10)

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
INSERT INTO Professores(id, Nome) VALUES ('12', 'MÁRIO')

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
insert into Usuarios (id, CPF, CursoId, Matricula, Nome) values ('99', '99999999999', 1, '654321', 'Demo2' )
SET IDENTITY_INSERT Usuarios OFF

select * from dbo.Disciplinas

INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('1', 'Matemática Discreta', 4, 0, 1, 2015, 1, 99, '99')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('2', 'Lógica Matemática', 4, 0, 1, 2015, 1, 99, '99')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('3', 'Introdução à Administração', 4, 0, 1, 2015, 1, 99, '99')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('4', 'Introdução à Computação', 10, 4, 1, 2015, 1, 99, '99')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('5', 'Fundamentos de Programação', 8, 0, 1, 2015, 1, 99, '99')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('6', 'Português Instrumental', 3, 0, 1, 2015, 1, 99, '99')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('7', 'Cálculo I', 6, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('8', 'Fundamentos de Sistema de Informação', 4, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('9', 'Arquitetura e Organização de Computadores', 4, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('10', 'Paradigma Orientado a Objetos', 6, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('11', 'Educação e Diversidade', 3, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('12', 'Inglês Instrumental', 2, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('13', 'Informática Ética e Sociedade', 2, 0, 2, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('14', 'Metodologia Científica', 3, 0, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('15', 'Modelagem de Dados', 4, 25, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('16', 'Sistemas Operacionais', 4, 0, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('17', 'Análise Orientada a Objetos', 4, 0, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('18', 'Algoritmos e Estrutura de Dados I', 6, 0, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('19', 'Engenharia de Software', 4, 25, 3, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('20', 'Probabilidade e Estatística', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('21', 'Projeto de Banco de Dados', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo1, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('22', 'Redes de Computadores', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('23', 'Padrões de Projeto e Arquitetura de Software', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('24', 'Algoritmos e Estrutura de Dados II', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('25', 'Qualidade de Software', 4, 0, 4, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('26', 'Projeto Integrador I', 2, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('27', 'Adm de Banco de Dados', 4, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('28', 'Lab de Redes de Computadores', 4, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('29', 'Programação Web I', 4, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('30', 'Gerência de Projetos', 4, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('31', 'Teste de Software', 2, 0, 5, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('32', 'Modelagem de processo de Negócio', 2, 90, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('33', 'Sistema de Apoio a Decisão', 4, 0, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('34', 'Sistemas Distribuídos', 2, 0, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('35', 'Programação Web II', 6, 0, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('36', 'Governança de TI', 4, 0, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('37', 'Indtrodução Humano Computador', 2, 0, 6, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('38', 'Projeto e Análise de Algoritmos', 2, 0, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('39', 'TCC I', 1, 127, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('40', 'Segurança e Auditoria', 1, 0, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('41', 'Projeto Integrador II', 4, 0, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('42', 'Orientação a Estágio', 2, 70, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('43', 'Programação Para Dispositivos Móveis', 4, 0, 7, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('44', 'Empreendedorismo', 4, 0, 8, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('45', 'TCC II', 1, 0, 8, 2015, 1, 99, '88')
INSERT INTO Disciplinas(id, Nome, QtdCreditos, QtdPreRequisitosCreditos, Periodo, AnoPPC, CursoId, SemestreId, UsuarioId) VALUES ('46', 'Computação Inteligente', 4, 0, 8, 2015, 1, 99, '88')

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

select * from dbo.MatriculaDisciplinas

Insert into dbo.MatriculaDisciplinas(Status,	AlunoId,	DisciplinaId1,	DisciplinaId) values (1,88,'1',1)
Insert into dbo.MatriculaDisciplinas(Status,	AlunoId,	DisciplinaId1,	DisciplinaId) values (1,88,'2',2)
Insert into dbo.MatriculaDisciplinas(Status,	AlunoId,	DisciplinaId1,	DisciplinaId) values (1,88,'3',3)
Insert into dbo.MatriculaDisciplinas(Status,	AlunoId,	DisciplinaId1,	DisciplinaId) values (1,88,'4',4)
Insert into dbo.MatriculaDisciplinas(Status,	AlunoId,	DisciplinaId1,	DisciplinaId) values (1,88,'5',5)
Insert into dbo.MatriculaDisciplinas(Status,	AlunoId,	DisciplinaId1,	DisciplinaId) values (1,88,'6',6)

commit
