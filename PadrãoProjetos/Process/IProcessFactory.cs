public interface IProcessFactory
{
    public WagePaymentProcess CreateWagePaymentProcess();
    public DismissalProcess CreateDismissalProcess();
    public AdmissionProcess CreateAdmissionProcess();
}

