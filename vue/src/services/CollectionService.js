import axios from 'axios';

const path = '/collection';

export default {
    getCollections(user) {
        return axios.get(path + '/user/' + user)
    },

    addCollection(collection){
        return axios.post(path, collection)
    },

    getIssues(collectionId) {
        return axios.get(path + '/' + collectionId)
    },

    getPublicCollections() {
        return axios.get(path)
    },
}