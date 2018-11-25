compiletoflash
HEX
50000504 CONSTANT GPIO_OUT  \ set by default to pin P0.24.  Want it to be P0.06
50000508 CONSTANT GPIO_OUTSET \ needed to set the GPIO_OUT register
50000510 CONSTANT GPIO_IN   \ set by default to pin p0.25.  Want it to be P0.08
50000514 CONSTANT GPIO_DIR   
50000518 CONSTANT GPIO_DIRSET \ needed to set the GPIO_DIR register   
50000718 CONSTANT GPIO_PIN_CNF[6] \ we want pin P0.06 as the output pin
50000720 CONSTANT GPIO_PIN_CNF[8] \ we want pin P0.08 as the input pin
50000760 CONSTANT GPIO_PIN_CNF[24] \ pin P0.24 is the default output pin.  Default value = 0x1
50000764 CONSTANT GPIO_PIN_CNF[25] \ pin P0.25 is the default input pin.  Default value = 0xC

BINARY
: SET_PIN_P0.6  0001  GPIO_PIN_CNF[6] ! ;
: SET_PIN_P0.8  1100 GPIO_PIN_CNF[8] ! ;  \ set as input with pulldown resistor
: SET_GPIO_DIRSET 1000000 GPIO_DIRSET ! ;
: SET_GPIO_OUTSET  1000000 GPIO_OUTSET ! ;  \ Set pin P0.06 to be an output pin.
: SET_GPIO SET_GPIO_DIRSET SET_PIN_P0.6 SET_PIN_P0.8 SET_GPIO_OUTSET SET_GPIO_IN ; \ handle all GPIO register changes

HEX
40002500 constant UART_ENABLE  \ Note: UART must be disabled before changing TXD and RXD pin assignments
: UART_ENABLE! HEX 4 UART_ENABLE ! ;  \ enable the UART
: UART_DISABLE! HEX 0 UART_ENABLE ! ; \ disable the UART

40002508 CONSTANT UART_PSEL.RTS  \ set by default to no pin at all
4000250C CONSTANT UART_PSEL.TXD  \ set by default to pin P0.24.  Want it to be P0.06
40002510 CONSTANT UART_PSEL.CTS  \ set by default to no pin at all
40002514 CONSTANT UART_PSEL.RXD  \ set by default to pin P0.25.  Want it to be P0.08
DECIMAL
: SET_UART_PSEL.TXD  6 UART_PSEL.TXD ! ;  \ Change from pin P0.24 (default) to P0.06
: SET_UART_PSEL.RXD  8 UART_PSEL.RXD ! ;  \ Change from pin P0.25 (default) to P0.08
: SET_UART SET_UART_PSEL.TXD SET_UART_PSEL.RXD  ; \ handle all UART register changes

: CHANGE_UART_PINS UART_DISABLE!  SET_GPIO SET_UART UART_ENABLE! ;  \ the one word that does it all
: INIT CHANGE_UART_PINS ;  \ automatically make the change on every reset
