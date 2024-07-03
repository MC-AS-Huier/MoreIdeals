using Next.Api.Bases;

namespace Next.Api.Interfaces;

public interface INextButton
{
    public ButtonBase Base { get; set; }

    public void OnRegister(INextButtonManager _nextButtonManager)
    {
    }

    public void OnUnRegister(INextButtonManager _nextButtonManager)
    {
    }
}