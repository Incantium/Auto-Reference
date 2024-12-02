namespace Incantium.Attributes
{
    /// <summary>
    /// Enum for the three globally recognized target locations to get another component from the current game object,
    /// or those that surround it. These are:
    /// <ul>
    ///     <li><see cref="Target.Current"/>: GetComponent()</li>
    ///     <li><see cref="Target.Child"/>: GetComponentInChildren()</li>
    ///     <li><see cref="Target.Parent"/>: GetComponentInParent()</li>
    /// </ul>
    /// </summary>
    public enum Target 
    {
        /// <summary>
        /// Reference the component on the current game object.
        /// </summary>
        Current,
        
        /// <summary>
        /// Reference the component on a child of the current game object.
        /// </summary>
        Child,
        
        /// <summary>
        /// Reference the component on the parent of the current game object.
        /// </summary>
        Parent
    }
}