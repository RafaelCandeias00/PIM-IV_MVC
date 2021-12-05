var ValidarExclusao = function (id, evento) {
    if (confirm("Deseja excluir?")) {
        return true;
    } else {
        evento.preventDefault();
        return false;
    }
}