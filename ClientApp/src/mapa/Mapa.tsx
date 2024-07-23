import React, { useState } from 'react'
import { GoogleMap, Marker, useJsApiLoader } from '@react-google-maps/api';
import MarkerCard from './MarkerCard';
import { IVisitaDomiciliar } from '../interfaces/IVisitaDomiciliar';

const containerStyle = {
    width: '100%',
    height: '100%'
};

const center = {
    lat: -3.745,
    lng: -38.523
};

const googleMapsApiKey = "AIzaSyBx28jLY1cM4KfUC8btE56_QUIbtvdCviA";

function Mapa({ visitasDomiciliar }: { visitasDomiciliar: IVisitaDomiciliar[] }) {
    const [visitaDomiciliar, setVisitaDomiciliar] = useState<IVisitaDomiciliar>();
    const { isLoaded } = useJsApiLoader({
        id: 'google-map-script',
        googleMapsApiKey: googleMapsApiKey
    })
    const [map, setMap] = React.useState(null)

    const onLoad = React.useCallback(function callback(map: any) {
        // This is just an example of getting and using the map instance!!! don't just blindly copy!
        //  const bounds = new window.google.maps.LatLngBounds(marks.length > 0 && marks[0].lat && marks[0].lng ? { lat: marks[0].lat, lng: marks[0].lng } : center);
        //  map.fitBounds(bounds);

        setMap(map)
    }, [])

    const onUnmount = React.useCallback(function callback(map: any) {
        setMap(null)
    }, [])

    return isLoaded ? (
        <GoogleMap
            mapContainerStyle={containerStyle}
            center={visitaDomiciliar
                ? { lat: visitaDomiciliar!.latitude || 0, lng: visitaDomiciliar!.longitude || 0 }
                : visitasDomiciliar.length > 0 ? { lat: visitasDomiciliar[0]!.latitude || 0, lng: visitasDomiciliar[0]!.longitude || 0 }
                    : center}
            zoom={15}
            onLoad={onLoad}
            onUnmount={onUnmount}

        >
            { /* Child components, such as markers, info windows, etc. */}
            {visitaDomiciliar && <MarkerCard visitaDomiciliar={visitaDomiciliar} setVisitaDomiciliar={setVisitaDomiciliar} />}
            {visitasDomiciliar.map((visita) =>
                <Marker
                    position={{ lat: visita!.latitude || 0, lng: visita!.longitude || 0 }}
                    title={visita!.cidadao?.nome || visita!.estabelecimento?.nome || visita.id.toString()}
                    onClick={() => setVisitaDomiciliar(visita)}
                    key={visita.id}
                />
            )}
            <></>
        </GoogleMap>
    ) : <></>
}

export default React.memo(Mapa)