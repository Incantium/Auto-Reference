namespace Incantium.Attributes
{
    /// <summary>
    /// Enum for the three globally recognized target locations to get another component from the current game object,
    /// or those that surround it.
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
        Children,
        
        /// <summary>
        /// Reference the component on the parent of the current game object.
        /// </summary>
        Parent
    }
}