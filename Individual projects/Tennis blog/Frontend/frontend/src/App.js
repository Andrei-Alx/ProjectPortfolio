import { Route, Routes, BrowserRouter as Router } from "react-router-dom";
import './App.css';
import Navbar from './components/Navbar/Navbar'
import HighlightsPage from "./pages/HighlightsPage";
import ProfilePage from "./pages/ProfilePage";
import HomePage from "./pages/HomePage";
import RankingsPage from "./pages/RankingsPage";
import PostDetailsPage from "./pages/PostDetailsPage";
import LogInPage from "./pages/LogInPage";
import AdminHomePage from "./pages/AdminHomePage";
import UserManagementPage from "./pages/UserManagementPage";
import NotificationsPage from "./pages/NotificationsPage"
import UnauthorizedPage from "./pages/UnauthorizedPage";
import React, { useState } from 'react';
import { Client } from '@stomp/stompjs';
import { v4 as uuidv4 } from 'uuid';
import MyPostsPage from "./pages/MyPostsPage";


function App() {
  const [stompClient, setStompClient] = useState();
  const [messagesReceived, setMessagesReceived] = useState([]);
  const SENDER = "Tennis Titans";

  const setupStompClient = () => {
    // stomp client over websockets
    const stompClient = new Client({
      brokerURL: 'ws://localhost:8090/ws',
      reconnectDelay: 5000,
      heartbeatIncoming: 4000,
      heartbeatOutgoing: 4000
    });

    stompClient.onConnect = () => {
      // subscribe to the backend public topic
      stompClient.subscribe('/topic/publicmessages', (data) => {
        onMessageReceived(data);
      });
    };

    // initiate client
    stompClient.activate();

    // maintain the client for sending and receiving
    setStompClient(stompClient);
  };

  // send the data using Stomp
  const sendMessage = (newMessage) => {
    const payload = { 'id': uuidv4(), 'from': SENDER, 'to': newMessage.to, 'text': newMessage.text };
    if (stompClient && stompClient.connected) {
      stompClient.publish({ 'destination': '/topic/publicmessages', body: JSON.stringify(payload) });
    } else {
      alert('Stomp client not yet connected.');
    }
  };

  // display the received data
  const onMessageReceived = (data) => {
    const message = JSON.parse(data.body);
    setMessagesReceived(messagesReceived => [...messagesReceived, message]);
  };

  const onUsernameInformed = () => {
    setupStompClient();
  }

  return (
    <div className="App">
      <Router>
        <Navbar />
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/highlights" element={<HighlightsPage />} />
          <Route path="/myposts" element={<MyPostsPage />} />
          <Route path="/profile" element={<ProfilePage onUsernameInformed={onUsernameInformed} onMessageSend={sendMessage}/>} />
          <Route path="/rankings" element={<RankingsPage />} />
          <Route exact path="/posts/:id" element={<PostDetailsPage onUsernameInformed={onUsernameInformed}/>} />
          <Route path="/login" element={<LogInPage />} />
          <Route path="/admin" element={<AdminHomePage />} />
          <Route path="/userManagement" element={<UserManagementPage />} />
          <Route path="/unauthorized" element={<UnauthorizedPage />} />
          <Route path="/notifications" element={<NotificationsPage onUsernameInformed={onUsernameInformed} messagesReceived={messagesReceived}/>} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
