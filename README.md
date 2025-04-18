# Web-Service-for-Parallel-Computing

## Project Description
WebServiceProgRozpr is a web service developed on the ASP.NET Core platform that provides an API for performing computationally intensive operations using parallel computing. The project demonstrates the application of various approaches to distributed and parallel computing in a web environment.

## Key Features
### 1. Matrix Multiplication
The service provides functionality for:
- Reading matrices from files in a special format
- Parallel matrix multiplication using `Parallel.For`
- Saving results to a file with a unique name

### 2. Mandelbrot Set Visualization
The service allows:
- Generating images of the Mandelbrot set
- Customizing image parameters and details
- Processing calculations in parallel to improve performance

## Technologies
- **ASP.NET Core** - web framework foundation
- **C# 13.0** - programming language
- **.NET 9.0** - target platform
- **SOAP** - for providing web services
- **REST API** - for providing HTTP endpoints
- **Docker** - application containerization
- **Docker Compose** - container orchestration

## Project Structure
Main project components:
- **Services** - business logic implementations:
    - `MatrixMultiplyService` - service for matrix operations
    - `MandelbrotSetService` - service for Mandelbrot set generation

- **Controllers** - API controllers:
    - `MatrixMultiplyController` - REST API for matrix operations
    - `MandelbrotSetController` - API for Mandelbrot set generation

## Running the Project
### Local Run
``` bash
dotnet restore
dotnet build
dotnet run --project WebServiceProgRozpr
```
### Using Docker
``` bash
docker-compose build
docker-compose up
```

## API
### REST API
### 
#### Matrix Operations
- `GET /Matrix/Filename/{filename}` - get matrix from a file
    - URL parameter: `filename` - path to the matrix file
    - Returns: Matrix as a 2D array of floats
    - Response codes:
        - `200 OK` - successfully retrieved matrix
        - `400 BadRequest` - filename is empty
        - `404 NotFound` - file not found
        - `500 InternalServerError` - file is not a matrix


- `GET /Matrix/Filename/{filename}` - get matrix from a file
    - URL parameter: `filename` - path to the matrix file
    - Returns: Matrix as a 2D array of floats
    - Response codes:
        - `200 OK` - successfully retrieved matrix
        - `400 BadRequest` - filename is empty
        - `404 NotFound` - file not found
        - `500 InternalServerError` - file is not a matrix

- `POST /Matrix/Upload` - upload matrix to server
    - Request body: Matrix as a 2D array of floats
    - Returns: Filename where the matrix was saved
    - Response codes:
        - `200 OK` - successfully saved matrix
        - `400 BadRequest` - matrix is empty
        - `500 InternalServerError` - error saving matrix to file


#### Mandelbrot Set Generation
- `GET /Api/MandelbrotSet` - generate Mandelbrot set image
    - Query parameters:
        - `height` - image height in pixels
        - `weight` - image width in pixels
        - `threads` - number of threads for parallel processing

    - Returns: PNG image file
    - Response codes:
        - `200 OK` - successfully generated image
        - `400 BadRequest` - invalid parameters
        - `500 InternalServerError` - server error during generation

## SOAP Client Application
The solution includes a SOAP client application for testing the SOAP services:
### Features
    - Creates and manages matrices
    - Performs matrix multiplication
    - Retrieves matrices from the service

### Running the SOAP Client

```bash
dotnet run --project soap_client_console
```

## Testing
The project includes a set of unit tests to verify the core functionality:
- Tests for `MatrixMultiplyService`:
    - Verification of reading matrices from files
    - Verification of matrix multiplication
    - Verification of proper error handling

### Running Tests
To run the tests, you can use this command:

#### Using dotnet CLI
``` bash
# Run all tests in the solution
dotnet test
```
#### Using Visual Studio
1. Open the solution in Visual Studio
2. Open the Test Explorer (Test > Test Explorer)
3. Click on "Run All Tests" or select specific tests to run

#### Using JetBrains Rider
1. Open the solution in Rider
2. Navigate to the unit tests (Unit Tests tool window)
3. Right-click on the test project or individual tests and select "Run"

## System Requirements
- .NET 9.0 SDK
- Docker (for container deployment)

## License
This project is distributed under the MIT license.
