#This is a simple TCP server for a chat program.
#The chat client is written in c# and is called Chatter!
#To run this python script you will need to download and install the Twisted library.
#
#Twisted can be found here http://twistedmatrix.com/trac/

# We are creating a gateway to a world 
from twisted.internet.protocol import Protocol, Factory
from twisted.internet import reactor

# What the server does with what it receives
class ChatterServProtocol(Protocol):
	def __init__(self, factory):
		self.factory = factory
	# What to do when a connection is made
	def connectionMade(self):
		self.transport.write("`Black`Server: Welcome to Chatter! Have fun! *Amount of fun may vary\r\n")
		self.factory.clients.append(self)
		print "Connection Made"
	def dataReceived(self, data):
		print data
		for c in self.factory.clients:
			c.message(data)
	def message(self, message):
		self.transport.write(message)
	def connectionLost(self, reason):
		self.factory.clients.remove(self)
		print "Connection Lost"
	
# What listens on ports
class ChatterServFactory(Factory):
	def __init__(self):
		self.clients = []
	def buildProtocol(self, addr):
		return ChatterServProtocol(self)

# using tcp on port 4000
reactor.listenTCP(4000, ChatterServFactory())
reactor.run()