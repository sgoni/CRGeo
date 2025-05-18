# CRGeo

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

Rest API for querying the geographic distribution of Costa Rica.

### Built With

* ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
* ![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
* ![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)

<!-- GETTING STARTED -->
## Getting Started

Installation and prerequisites.


### Prerequisites

* Docker: https://docs.docker.com/engine/install/
* Visual Studio Community: https://visualstudio.microsoft.com/vs/community/

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/sgoni/CRGeo.git
   ```
2. Run Powershell and navigate to directory
   ```sh
   cd ..\CRGeo\src
   ```           
3. run the .sh file, this command will create a container consisting of the Postgres database instance with information about the Costa Rican Administrative Territorial Distribution and another container containing the query API.
    ```sh
        ./up.sh
    ```
   
<!-- USAGE EXAMPLES -->
## Usage

The Rest API currently contains 3 methods:

* Get Provinces
   ```sh
   curl -X 'GET' \
   'https://localhost:7070/Dta/Provinces' \
   -H 'accept: application/json'
   ```
* Get Cities by Province Id
   ```sh
   curl -X 'GET' \
   'https://localhost:7070/Dta/cities/1' \
   -H 'accept: application/json'
   ```
    
* Get districts by City Id
   ```sh
   curl -X 'GET' \
   'https://localhost:7070/Dta/districts/202' \
   -H 'accept: application/json'
   ``` 
In the ...\CRGeo\tools\postman\ folder, you can find the "CRGeo.backend.API.postman_collection.json" file, which contains the definition of the Postman collection.

<!-- ROADMAP -->
## Roadmap

- [ ] Add new query methods by name.
- [ ] Add Additional Templates w/ Examples

<!-- CONTRIBUTING -->
## Contributing

<!-- LICENSE -->
## License

Distributed under the Unlicense License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->
## Contact

Steven Goni Segura - [linkedin.com/in/steven-g-109390925](linkedin.com/in/steven-g-109390925) - steven.goni@outlook.com

Project Link: [https://github.com/sgoni/CRGeo.git](https://github.com/sgoni/CRGeo.git)

<p align="right">(<a href="#readme-top">back to top</a>)</p>