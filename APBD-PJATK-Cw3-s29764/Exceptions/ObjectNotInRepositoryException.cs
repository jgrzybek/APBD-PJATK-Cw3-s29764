namespace APBD_PJATK_Cw3_s29764.Exceptions;

public class ObjectNotInRepositoryException : Exception
{
    public ObjectNotInRepositoryException(int id) : base($"Object with ID: {id} is not in the repository") {}

    public ObjectNotInRepositoryException(string buildingCode) : 
        base($"Object with building code: {buildingCode} is not in the repository") {}
}