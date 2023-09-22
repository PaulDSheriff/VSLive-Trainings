using System.ComponentModel;

namespace Common.Library;

public abstract class CommonBase : INotifyPropertyChanged
{
  #region Constructor
  /// <summary>
  /// Constructor for CommonBase class
  /// </summary>
  public CommonBase()
  {
    Init();
  }
  #endregion

  #region Init Method
  /// <summary>
  /// Initialize any properties of this class
  /// </summary>
  public virtual void Init()
  {
  }
  #endregion

  #region RaisePropertyChanged Method
  /// <summary>
  /// Event used to raise changes to any bound UI objects
  /// </summary>
  public event PropertyChangedEventHandler? PropertyChanged;

  public virtual void RaisePropertyChanged(string propertyName)
  {
    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
  #endregion
}
