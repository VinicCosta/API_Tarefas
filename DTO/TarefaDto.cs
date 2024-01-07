namespace API_Tarefas.DTO
{
    public record TarefaDto
    {
        public string Titulo { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public bool Concluida { get; set; } = default!;
    }
}