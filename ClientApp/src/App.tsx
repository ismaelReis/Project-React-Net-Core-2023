import jsonServerProvider from 'ra-data-json-server';
import { Admin, ListGuesser, Resource } from 'react-admin';


const dataProvider = jsonServerProvider('api');

function App() {
    return (
        <Admin
            dataProvider={dataProvider}
        >
            <Resource
                name="cidadaos"
                list={ListGuesser}
                options={{ label: "Cidadãos" }}
            />
            <Resource
                name="visitasDomiciliar"
                list={ListGuesser}
                options={{ label: "Visitas domiciliares" }}
            />
            <Resource
                name="funcionarios"
                list={ListGuesser}
                options={{ label: "Funcionários" }}
            />
        </Admin>
    );
}

export default App;
