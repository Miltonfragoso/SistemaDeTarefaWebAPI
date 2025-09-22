using System.ComponentModel;

namespace SistemaDeTarefasWebAPI.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluida = 3
    }
}
