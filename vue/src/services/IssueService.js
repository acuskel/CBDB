import axios from 'axios';

const path = '/issue';

export default {
    getAllIssues() {
       return axios.get(path + '/all')
 },

    addIssue(issue, collectionId){
        console.log(issue, collectionId)
        return axios.post(path + '/' + collectionId, issue)
    },

    deleteIssueFromCollection(collectionId, issueId){
        return axios.delete(path + '/' + collectionId + '/' + issueId)
    }
}