    private CheckingEndLevel _checkingEndLevel;

    [Inject]
    internal EndLevelService(CheckingEndLevel checkingEndLevel)
    {
        _checkingEndLevel = checkingEndLevel;
    }

    public void Init(IReadOnlyList<IDamageble> enemies, IDamageble gun)
    {
        _checkingEndLevel.Init(enemies, gun);
    }

    public void Update()
    {

    }

    public void Disable()
    {
        _checkingEndLevel.Disable();
    }
}
