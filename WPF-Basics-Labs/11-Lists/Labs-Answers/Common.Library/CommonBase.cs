using System.ComponentModel;

namespace Common.Library;

/// <summary>
/// This class should be inherited by all other classes in your common library
/// </summary>
public abstract class CommonBase : INotifyPropertyChanged
{
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