public static class GameMode {
    public enum PlayingMode
    {
        singlePlayer,
        multiPlayer
    };
    public enum PlayerModel
    {
        kun,
        peng
    }
    static public PlayerModel playerModel;
    static public PlayingMode playingMode;
}