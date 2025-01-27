public class EstadosUnidosDismissalProcess : DismissalProcess
{
    public override string Title => "Demissão de Funcionário";
    public override void Apply(DismissalArgs args)
    {
        args.Company.Money -= 2 * args.Employe.Wage;
    }
}

public class EstadosUnidosWagePaymentProcess : WagePaymentProcess
{
    public override string Title => "Pagamento de Salário";
    public override void Apply(WagePaymentArgs args)
    {
        args.Company.Money -= 1.45m * args.Employe.Wage + 500;
    }
}

public class EstadosUnidosAdmissionProcess : AdmissionProcess
{
    public override string Title => "Contratação de funcionário";

    public override void Apply(AdmissionArgs args)
    {
        args.Company.Money -= args.Employe.Wage * 0.67m;
    }
}

public class EstadosUnidosProcessFactory : IProcessFactory
{
    public AdmissionProcess CreateAdmissionProcess()
        => new EstadosUnidosAdmissionProcess();

    public DismissalProcess CreateDismissalProcess()
        => new EstadosUnidosDismissalProcess();
    public WagePaymentProcess CreateWagePaymentProcess()
        => new EstadosUnidosWagePaymentProcess();
}