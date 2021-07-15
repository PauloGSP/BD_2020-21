CREATE TRIGGER CriarAlunoGrupo ON projeto.AlunoGrupo AFTER INSERT, UPDATE AS
BEGIN
	IF EXISTS(
		SELECT * FROM projeto.AlunoGrupo ag INNER JOIN projeto.GrupoAluno ga ON ag.DesignacaoGrupo = ga.Designacao WHERE NumCCAluno = NumCCProfessor
	) 
	BEGIN
		RAISERROR('Professor não pode ser aluno!', 16, 1);
		ROLLBACK TRAN;
	END
	
	IF EXISTS(
		SELECT Designacao, COUNT(*) Participantes, NumMax FROM projeto.GrupoAluno ga 
		INNER JOIN projeto.AlunoGrupo ag ON ga.Designacao = ag.DesignacaoGrupo GROUP BY Designacao, NumMax HAVING COUNT(*) > NumMax
	) 
	BEGIN
		RAISERROR('Grupo está cheio!', 16, 1);
		ROLLBACK TRAN;
	END
END
